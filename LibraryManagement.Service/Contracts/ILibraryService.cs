using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using LibraryManagement.Service.DTOs;
using LibraryManagement.Service.Responses;

namespace LibraryManagement.Service.Contracts
{
    [ServiceContract]
    public interface ILibraryService
    {

        [OperationContract]
        [WebGet(
            UriTemplate = "/books",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ApiResponse<List<BookDto>> GetAllBooks();

        [OperationContract]
        [WebGet(
            UriTemplate = "/books/{id}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ApiResponse<BookDto> GetBookById(string id);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/books/add",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ApiResponse<BookDto> AddBook(CreateBookRequest request);

        [OperationContract]
        [WebInvoke(
            Method = "PUT",
            UriTemplate = "/books/update",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ApiResponse<BookDto> UpdateBook(UpdateBookRequest request);

        [OperationContract]
        [WebInvoke(
            Method = "DELETE",
            UriTemplate = "/books/delete/{id}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ApiResponse<bool> DeleteBook(string id);


        [OperationContract]
        [WebGet(
            UriTemplate = "/members",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ApiResponse<List<MemberDto>> GetAllMembers();

        [OperationContract]
        [WebGet(
            UriTemplate = "/members/{id}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ApiResponse<MemberDto> GetMemberById(string id);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/members/add",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ApiResponse<MemberDto> AddMember(CreateMemberRequest request);

        [OperationContract]
        [WebInvoke(
            Method = "PUT",
            UriTemplate = "/members/update",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ApiResponse<MemberDto> UpdateMember(UpdateMemberRequest request);

        [OperationContract]
        [WebInvoke(
            Method = "DELETE",
            UriTemplate = "/members/delete/{id}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ApiResponse<bool> DeleteMember(string id);


        [OperationContract]
        [WebGet(
            UriTemplate = "/transactions",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ApiResponse<List<BorrowTransactionDto>> GetAllTransactions();

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/borrow",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ApiResponse<BorrowTransactionDto> BorrowBook(BorrowBookRequest request);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/return",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ApiResponse<BorrowTransactionDto> ReturnBook(ReturnBookRequest request);
    }
}