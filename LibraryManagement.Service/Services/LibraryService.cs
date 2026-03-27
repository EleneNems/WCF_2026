using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.Data.Context;
using LibraryManagement.Data.Entities;
using LibraryManagement.Service.Contracts;
using LibraryManagement.Service.DTOs;
using LibraryManagement.Service.Responses;
using System.Transactions;

namespace LibraryManagement.Service.Services
{
    public class LibraryService : ILibraryService
    {
        public ApiResponse<List<BookDto>> GetAllBooks()
        {
            try
            {
                using (var context = new LibraryDbContext())
                {
                    var books = context.Books
                        .Where(x => !x.IsDeleted)
                        .Select(x => new BookDto
                        {
                            Id = x.Id,
                            Title = x.Title,
                            Author = x.Author,
                            ISBN = x.ISBN,
                            Quantity = x.Quantity,
                            AvailableQuantity = x.AvailableQuantity
                        })
                        .ToList();

                    return new ApiResponse<List<BookDto>>
                    {
                        Success = true,
                        Message = "Books retrieved successfully.",
                        Data = books
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<BookDto>>
                {
                    Success = false,
                    Message = "Error while retrieving books: " + ex.Message,
                    Data = null
                };
            }
        }

        public ApiResponse<BookDto> GetBookById(string id)
        {
            try
            {
                if (!int.TryParse(id, out int bookId))
                {
                    return new ApiResponse<BookDto>
                    {
                        Success = false,
                        Message = "Invalid book id.",
                        Data = null
                    };
                }

                using (var context = new LibraryDbContext())
                {
                    var book = context.Books.FirstOrDefault(x => x.Id == bookId && !x.IsDeleted);

                    if (book == null)
                    {
                        return new ApiResponse<BookDto>
                        {
                            Success = false,
                            Message = "Book not found.",
                            Data = null
                        };
                    }

                    return new ApiResponse<BookDto>
                    {
                        Success = true,
                        Message = "Book retrieved successfully.",
                        Data = new BookDto
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Author = book.Author,
                            ISBN = book.ISBN,
                            Quantity = book.Quantity,
                            AvailableQuantity = book.AvailableQuantity
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<BookDto>
                {
                    Success = false,
                    Message = "Error while retrieving book: " + ex.Message,
                    Data = null
                };
            }
        }

        public ApiResponse<BookDto> AddBook(CreateBookRequest request)
        {
            try
            {
                if (request == null)
                {
                    return new ApiResponse<BookDto>
                    {
                        Success = false,
                        Message = "Request is null.",
                        Data = null
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Title))
                {
                    return new ApiResponse<BookDto>
                    {
                        Success = false,
                        Message = "Title is required.",
                        Data = null
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Author))
                {
                    return new ApiResponse<BookDto>
                    {
                        Success = false,
                        Message = "Author is required.",
                        Data = null
                    };
                }

                if (string.IsNullOrWhiteSpace(request.ISBN))
                {
                    return new ApiResponse<BookDto>
                    {
                        Success = false,
                        Message = "ISBN is required.",
                        Data = null
                    };
                }

                if (request.Quantity < 0)
                {
                    return new ApiResponse<BookDto>
                    {
                        Success = false,
                        Message = "Quantity cannot be negative.",
                        Data = null
                    };
                }

                using (var context = new LibraryDbContext())
                {
                    bool isbnExists = context.Books.Any(x => x.ISBN == request.ISBN.Trim() && !x.IsDeleted);

                    if (isbnExists)
                    {
                        return new ApiResponse<BookDto>
                        {
                            Success = false,
                            Message = "ISBN already exists.",
                            Data = null
                        };
                    }

                    var book = new LibraryManagement.Data.Entities.Book
                    {
                        Title = request.Title.Trim(),
                        Author = request.Author.Trim(),
                        ISBN = request.ISBN.Trim(),
                        Quantity = request.Quantity,
                        AvailableQuantity = request.Quantity,
                        CreatedAt = DateTime.Now,
                        IsDeleted = false
                    };

                    context.Books.Add(book);
                    context.SaveChanges();

                    return new ApiResponse<BookDto>
                    {
                        Success = true,
                        Message = "Book added successfully.",
                        Data = new BookDto
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Author = book.Author,
                            ISBN = book.ISBN,
                            Quantity = book.Quantity,
                            AvailableQuantity = book.AvailableQuantity
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<BookDto>
                {
                    Success = false,
                    Message = "Error while adding book: " + ex.Message,
                    Data = null
                };
            }
        }

        public ApiResponse<BookDto> UpdateBook(UpdateBookRequest request)
        {
            try
            {
                if (request == null)
                {
                    return new ApiResponse<BookDto>
                    {
                        Success = false,
                        Message = "Request is null.",
                        Data = null
                    };
                }

                if (request.Id <= 0)
                {
                    return new ApiResponse<BookDto>
                    {
                        Success = false,
                        Message = "Invalid book id.",
                        Data = null
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Title))
                {
                    return new ApiResponse<BookDto>
                    {
                        Success = false,
                        Message = "Title is required.",
                        Data = null
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Author))
                {
                    return new ApiResponse<BookDto>
                    {
                        Success = false,
                        Message = "Author is required.",
                        Data = null
                    };
                }

                if (string.IsNullOrWhiteSpace(request.ISBN))
                {
                    return new ApiResponse<BookDto>
                    {
                        Success = false,
                        Message = "ISBN is required.",
                        Data = null
                    };
                }

                if (request.Quantity < 0)
                {
                    return new ApiResponse<BookDto>
                    {
                        Success = false,
                        Message = "Quantity cannot be negative.",
                        Data = null
                    };
                }

                using (var context = new LibraryDbContext())
                {
                    var book = context.Books.FirstOrDefault(x => x.Id == request.Id && !x.IsDeleted);

                    if (book == null)
                    {
                        return new ApiResponse<BookDto>
                        {
                            Success = false,
                            Message = "Book not found.",
                            Data = null
                        };
                    }

                    bool isbnExists = context.Books.Any(x =>
                        x.ISBN == request.ISBN.Trim() &&
                        x.Id != request.Id &&
                        !x.IsDeleted);

                    if (isbnExists)
                    {
                        return new ApiResponse<BookDto>
                        {
                            Success = false,
                            Message = "ISBN already exists.",
                            Data = null
                        };
                    }

                    int borrowedCount = book.Quantity - book.AvailableQuantity;

                    if (request.Quantity < borrowedCount)
                    {
                        return new ApiResponse<BookDto>
                        {
                            Success = false,
                            Message = "Quantity cannot be less than borrowed books count.",
                            Data = null
                        };
                    }

                    book.Title = request.Title.Trim();
                    book.Author = request.Author.Trim();
                    book.ISBN = request.ISBN.Trim();
                    book.Quantity = request.Quantity;
                    book.AvailableQuantity = request.Quantity - borrowedCount;

                    context.SaveChanges();

                    return new ApiResponse<BookDto>
                    {
                        Success = true,
                        Message = "Book updated successfully.",
                        Data = new BookDto
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Author = book.Author,
                            ISBN = book.ISBN,
                            Quantity = book.Quantity,
                            AvailableQuantity = book.AvailableQuantity
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<BookDto>
                {
                    Success = false,
                    Message = "Error while updating book: " + ex.Message,
                    Data = null
                };
            }
        }

        public ApiResponse<bool> DeleteBook(string id)
        {
            try
            {
                if (!int.TryParse(id, out int bookId))
                {
                    return new ApiResponse<bool>
                    {
                        Success = false,
                        Message = "Invalid book id.",
                        Data = false
                    };
                }

                using (var context = new LibraryDbContext())
                {
                    var book = context.Books.FirstOrDefault(x => x.Id == bookId && !x.IsDeleted);

                    if (book == null)
                    {
                        return new ApiResponse<bool>
                        {
                            Success = false,
                            Message = "Book not found.",
                            Data = false
                        };
                    }

                    bool hasActiveBorrow = context.BorrowTransactions.Any(x =>
                        x.BookId == bookId &&
                        x.Status == "Borrowed");

                    if (hasActiveBorrow)
                    {
                        return new ApiResponse<bool>
                        {
                            Success = false,
                            Message = "Book cannot be deleted because it is currently borrowed.",
                            Data = false
                        };
                    }

                    book.IsDeleted = true;
                    context.SaveChanges();

                    return new ApiResponse<bool>
                    {
                        Success = true,
                        Message = "Book deleted successfully.",
                        Data = true
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = "Error while deleting book: " + ex.Message,
                    Data = false
                };
            }
        }

        public ApiResponse<List<MemberDto>> GetAllMembers()
        {
            try
            {
                using (var context = new LibraryDbContext())
                {
                    var members = context.Members
                        .Where(x => !x.IsDeleted)
                        .Select(x => new MemberDto
                        {
                            Id = x.Id,
                            FullName = x.FullName,
                            Email = x.Email,
                            Phone = x.Phone
                        })
                        .ToList();

                    return new ApiResponse<List<MemberDto>>
                    {
                        Success = true,
                        Message = "Members retrieved successfully.",
                        Data = members
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<MemberDto>>
                {
                    Success = false,
                    Message = "Error while retrieving members: " + ex.Message,
                    Data = null
                };
            }
        }

        public ApiResponse<MemberDto> GetMemberById(string id)
        {
            try
            {
                if (!int.TryParse(id, out int memberId))
                {
                    return new ApiResponse<MemberDto>
                    {
                        Success = false,
                        Message = "Invalid member id.",
                        Data = null
                    };
                }

                using (var context = new LibraryDbContext())
                {
                    var member = context.Members.FirstOrDefault(x => x.Id == memberId && !x.IsDeleted);

                    if (member == null)
                    {
                        return new ApiResponse<MemberDto>
                        {
                            Success = false,
                            Message = "Member not found.",
                            Data = null
                        };
                    }

                    return new ApiResponse<MemberDto>
                    {
                        Success = true,
                        Message = "Member retrieved successfully.",
                        Data = new MemberDto
                        {
                            Id = member.Id,
                            FullName = member.FullName,
                            Email = member.Email,
                            Phone = member.Phone
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<MemberDto>
                {
                    Success = false,
                    Message = "Error while retrieving member: " + ex.Message,
                    Data = null
                };
            }
        }

        public ApiResponse<MemberDto> AddMember(CreateMemberRequest request)
        {
            try
            {
                if (request == null)
                {
                    return new ApiResponse<MemberDto>
                    {
                        Success = false,
                        Message = "Request is null.",
                        Data = null
                    };
                }

                if (string.IsNullOrWhiteSpace(request.FullName))
                {
                    return new ApiResponse<MemberDto>
                    {
                        Success = false,
                        Message = "Full name is required.",
                        Data = null
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ApiResponse<MemberDto>
                    {
                        Success = false,
                        Message = "Email is required.",
                        Data = null
                    };
                }

                string email = request.Email.Trim();

                if (!email.Contains("@") || !email.Contains("."))
                {
                    return new ApiResponse<MemberDto>
                    {
                        Success = false,
                        Message = "Email format is invalid.",
                        Data = null
                    };
                }

                using (var context = new LibraryDbContext())
                {
                    bool emailExists = context.Members.Any(x => x.Email == email && !x.IsDeleted);

                    if (emailExists)
                    {
                        return new ApiResponse<MemberDto>
                        {
                            Success = false,
                            Message = "Email already exists.",
                            Data = null
                        };
                    }

                    var member = new LibraryManagement.Data.Entities.Member
                    {
                        FullName = request.FullName.Trim(),
                        Email = email,
                        Phone = string.IsNullOrWhiteSpace(request.Phone) ? null : request.Phone.Trim(),
                        CreatedAt = DateTime.Now,
                        IsDeleted = false
                    };

                    context.Members.Add(member);
                    context.SaveChanges();

                    return new ApiResponse<MemberDto>
                    {
                        Success = true,
                        Message = "Member added successfully.",
                        Data = new MemberDto
                        {
                            Id = member.Id,
                            FullName = member.FullName,
                            Email = member.Email,
                            Phone = member.Phone
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<MemberDto>
                {
                    Success = false,
                    Message = "Error while adding member: " + ex.Message,
                    Data = null
                };
            }
        }

        public ApiResponse<MemberDto> UpdateMember(UpdateMemberRequest request)
        {
            try
            {
                if (request == null)
                {
                    return new ApiResponse<MemberDto>
                    {
                        Success = false,
                        Message = "Request is null.",
                        Data = null
                    };
                }

                if (request.Id <= 0)
                {
                    return new ApiResponse<MemberDto>
                    {
                        Success = false,
                        Message = "Invalid member id.",
                        Data = null
                    };
                }

                if (string.IsNullOrWhiteSpace(request.FullName))
                {
                    return new ApiResponse<MemberDto>
                    {
                        Success = false,
                        Message = "Full name is required.",
                        Data = null
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ApiResponse<MemberDto>
                    {
                        Success = false,
                        Message = "Email is required.",
                        Data = null
                    };
                }

                string email = request.Email.Trim();

                if (!email.Contains("@") || !email.Contains("."))
                {
                    return new ApiResponse<MemberDto>
                    {
                        Success = false,
                        Message = "Email format is invalid.",
                        Data = null
                    };
                }

                using (var context = new LibraryDbContext())
                {
                    var member = context.Members.FirstOrDefault(x => x.Id == request.Id && !x.IsDeleted);

                    if (member == null)
                    {
                        return new ApiResponse<MemberDto>
                        {
                            Success = false,
                            Message = "Member not found.",
                            Data = null
                        };
                    }

                    bool emailExists = context.Members.Any(x =>
                        x.Email == email &&
                        x.Id != request.Id &&
                        !x.IsDeleted);

                    if (emailExists)
                    {
                        return new ApiResponse<MemberDto>
                        {
                            Success = false,
                            Message = "Email already exists.",
                            Data = null
                        };
                    }

                    member.FullName = request.FullName.Trim();
                    member.Email = email;
                    member.Phone = string.IsNullOrWhiteSpace(request.Phone) ? null : request.Phone.Trim();

                    context.SaveChanges();

                    return new ApiResponse<MemberDto>
                    {
                        Success = true,
                        Message = "Member updated successfully.",
                        Data = new MemberDto
                        {
                            Id = member.Id,
                            FullName = member.FullName,
                            Email = member.Email,
                            Phone = member.Phone
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<MemberDto>
                {
                    Success = false,
                    Message = "Error while updating member: " + ex.Message,
                    Data = null
                };
            }
        }

        public ApiResponse<bool> DeleteMember(string id)
        {
            try
            {
                if (!int.TryParse(id, out int memberId))
                {
                    return new ApiResponse<bool>
                    {
                        Success = false,
                        Message = "Invalid member id.",
                        Data = false
                    };
                }

                using (var context = new LibraryDbContext())
                {
                    var member = context.Members.FirstOrDefault(x => x.Id == memberId && !x.IsDeleted);

                    if (member == null)
                    {
                        return new ApiResponse<bool>
                        {
                            Success = false,
                            Message = "Member not found.",
                            Data = false
                        };
                    }

                    bool hasActiveBorrow = context.BorrowTransactions.Any(x =>
                        x.MemberId == memberId &&
                        x.Status == "Borrowed");

                    if (hasActiveBorrow)
                    {
                        return new ApiResponse<bool>
                        {
                            Success = false,
                            Message = "Member cannot be deleted because they have borrowed books.",
                            Data = false
                        };
                    }

                    member.IsDeleted = true;
                    context.SaveChanges();

                    return new ApiResponse<bool>
                    {
                        Success = true,
                        Message = "Member deleted successfully.",
                        Data = true
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = "Error while deleting member: " + ex.Message,
                    Data = false
                };
            }
        }

        public ApiResponse<List<BorrowTransactionDto>> GetAllTransactions()
        {
            try
            {
                using (var context = new LibraryDbContext())
                {
                    var transactions = context.BorrowTransactions
                        .Select(x => new BorrowTransactionDto
                        {
                            Id = x.Id,
                            BookId = x.BookId,
                            BookTitle = x.Book.Title,
                            MemberId = x.MemberId,
                            MemberName = x.Member.FullName,
                            BorrowDate = x.BorrowDate,
                            ReturnDate = x.ReturnDate,
                            Status = x.Status
                        })
                        .ToList();

                    return new ApiResponse<List<BorrowTransactionDto>>
                    {
                        Success = true,
                        Message = "Transactions retrieved successfully.",
                        Data = transactions
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<BorrowTransactionDto>>
                {
                    Success = false,
                    Message = "Error while retrieving transactions: " + ex.Message,
                    Data = null
                };
            }
        }

        public ApiResponse<BorrowTransactionDto> BorrowBook(BorrowBookRequest request)
        {
            try
            {
                if (request == null)
                {
                    return new ApiResponse<BorrowTransactionDto>
                    {
                        Success = false,
                        Message = "Request is null.",
                        Data = null
                    };
                }

                if (request.BookId <= 0)
                {
                    return new ApiResponse<BorrowTransactionDto>
                    {
                        Success = false,
                        Message = "Invalid book id.",
                        Data = null
                    };
                }

                if (request.MemberId <= 0)
                {
                    return new ApiResponse<BorrowTransactionDto>
                    {
                        Success = false,
                        Message = "Invalid member id.",
                        Data = null
                    };
                }

                using (var scope = new TransactionScope())
                {
                    using (var context = new LibraryDbContext())
                    {
                        var book = context.Books.FirstOrDefault(x => x.Id == request.BookId && !x.IsDeleted);
                        if (book == null)
                        {
                            return new ApiResponse<BorrowTransactionDto>
                            {
                                Success = false,
                                Message = "Book not found.",
                                Data = null
                            };
                        }

                        var member = context.Members.FirstOrDefault(x => x.Id == request.MemberId && !x.IsDeleted);
                        if (member == null)
                        {
                            return new ApiResponse<BorrowTransactionDto>
                            {
                                Success = false,
                                Message = "Member not found.",
                                Data = null
                            };
                        }

                        if (book.AvailableQuantity <= 0)
                        {
                            return new ApiResponse<BorrowTransactionDto>
                            {
                                Success = false,
                                Message = "Book is not available.",
                                Data = null
                            };
                        }

                        bool alreadyBorrowed = context.BorrowTransactions.Any(x =>
                            x.BookId == request.BookId &&
                            x.MemberId == request.MemberId &&
                            x.Status == "Borrowed");

                        if (alreadyBorrowed)
                        {
                            return new ApiResponse<BorrowTransactionDto>
                            {
                                Success = false,
                                Message = "This member already has this book borrowed.",
                                Data = null
                            };
                        }

                        book.AvailableQuantity--;

                        var transaction = new BorrowTransaction
                        {
                            BookId = book.Id,
                            MemberId = member.Id,
                            BorrowDate = DateTime.Now,
                            ReturnDate = null,
                            Status = "Borrowed",
                            CreatedAt = DateTime.Now
                        };

                        context.BorrowTransactions.Add(transaction);
                        context.SaveChanges();

                        scope.Complete();

                        return new ApiResponse<BorrowTransactionDto>
                        {
                            Success = true,
                            Message = "Book borrowed successfully.",
                            Data = new BorrowTransactionDto
                            {
                                Id = transaction.Id,
                                BookId = transaction.BookId,
                                BookTitle = book.Title,
                                MemberId = transaction.MemberId,
                                MemberName = member.FullName,
                                BorrowDate = transaction.BorrowDate,
                                ReturnDate = transaction.ReturnDate,
                                Status = transaction.Status
                            }
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<BorrowTransactionDto>
                {
                    Success = false,
                    Message = "Error while borrowing book: " + ex.Message,
                    Data = null
                };
            }
        }

        public ApiResponse<BorrowTransactionDto> ReturnBook(ReturnBookRequest request)
        {
            try
            {
                if (request == null)
                {
                    return new ApiResponse<BorrowTransactionDto>
                    {
                        Success = false,
                        Message = "Request is null.",
                        Data = null
                    };
                }

                if (request.TransactionId <= 0)
                {
                    return new ApiResponse<BorrowTransactionDto>
                    {
                        Success = false,
                        Message = "Invalid transaction id.",
                        Data = null
                    };
                }

                using (var scope = new TransactionScope())
                {
                    using (var context = new LibraryDbContext())
                    {
                        var transaction = context.BorrowTransactions
                            .FirstOrDefault(x => x.Id == request.TransactionId);

                        if (transaction == null)
                        {
                            return new ApiResponse<BorrowTransactionDto>
                            {
                                Success = false,
                                Message = "Transaction not found.",
                                Data = null
                            };
                        }

                        if (transaction.Status == "Returned")
                        {
                            return new ApiResponse<BorrowTransactionDto>
                            {
                                Success = false,
                                Message = "Book is already returned.",
                                Data = null
                            };
                        }

                        var book = context.Books.FirstOrDefault(x => x.Id == transaction.BookId && !x.IsDeleted);
                        if (book == null)
                        {
                            return new ApiResponse<BorrowTransactionDto>
                            {
                                Success = false,
                                Message = "Related book not found.",
                                Data = null
                            };
                        }

                        var member = context.Members.FirstOrDefault(x => x.Id == transaction.MemberId && !x.IsDeleted);
                        if (member == null)
                        {
                            return new ApiResponse<BorrowTransactionDto>
                            {
                                Success = false,
                                Message = "Related member not found.",
                                Data = null
                            };
                        }

                        transaction.Status = "Returned";
                        transaction.ReturnDate = DateTime.Now;
                        book.AvailableQuantity++;

                        context.SaveChanges();

                        scope.Complete();

                        return new ApiResponse<BorrowTransactionDto>
                        {
                            Success = true,
                            Message = "Book returned successfully.",
                            Data = new BorrowTransactionDto
                            {
                                Id = transaction.Id,
                                BookId = transaction.BookId,
                                BookTitle = book.Title,
                                MemberId = transaction.MemberId,
                                MemberName = member.FullName,
                                BorrowDate = transaction.BorrowDate,
                                ReturnDate = transaction.ReturnDate,
                                Status = transaction.Status
                            }
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<BorrowTransactionDto>
                {
                    Success = false,
                    Message = "Error while returning book: " + ex.Message,
                    Data = null
                };
            }
        }
    }
}