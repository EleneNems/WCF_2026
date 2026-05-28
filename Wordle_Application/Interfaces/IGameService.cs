using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle_Application.DTOs;

namespace Wordle_Application.Interfaces
{
    public interface IGameService
    {
        Task<StartGameResponseDto> StartGameAsync(StartGameRequestDto request);
        Task<GuessResponseDto> GuessAsync(GuessRequestDto request);
    }
}
