using Classwork_4_Application.Interfaces;
using Classwork_4_Application.Interfaces.Repositories;

namespace Classwork_4_Application.Services;

public class StatisticsService : IStatisticsService
{
    private readonly IStatisticsRepository _statisticsRepository;

    public StatisticsService(IStatisticsRepository statisticsRepository)
    {
        _statisticsRepository = statisticsRepository;
    }

    public async Task<object> GetStatisticsAsync()
    {
        var totalBooksQuantity = await _statisticsRepository.GetTotalBooksQuantityAsync();
        var availableBooksQuantity = await _statisticsRepository.GetAvailableBooksQuantityAsync();
        var issuedBooksCount = await _statisticsRepository.GetIssuedBooksCountAsync();
        var lateReturnsCount = await _statisticsRepository.GetLateReturnsCountAsync();
        var blockedReadersCount = await _statisticsRepository.GetBlockedReadersCountAsync();
        var mostIssuedBook = await _statisticsRepository.GetMostIssuedBookAsync();
        var mostActiveReader = await _statisticsRepository.GetMostActiveReaderAsync();

        return new
        {
            TotalBooksQuantity = totalBooksQuantity,
            AvailableBooksQuantity = availableBooksQuantity,
            IssuedBooksCount = issuedBooksCount,
            LateReturnsCount = lateReturnsCount,
            BlockedReadersCount = blockedReadersCount,
            MostIssuedBook = mostIssuedBook,
            MostActiveReader = mostActiveReader
        };
    }
}