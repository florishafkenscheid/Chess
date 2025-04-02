using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpfish;
using ChessApp.Models.Moves;

namespace ChessApp.Services
{
    internal sealed class StockfishService : IDisposable
    {
        private readonly IStockfishEngine _engine;
        public StockfishService()
        {
            _engine = new StockfishEngine(@"..\..\..\stockfish.exe"); // "C:\\Users\\floris\\source\\repos\\florishafkenscheid\\ChessApp\\ChessApp\\bin\\Debug\\net8.0-windows" -> \ChessApp\stockfish.exe

            Initialize().Wait();
        }

        private async Task Initialize()
        {
            if (await _engine.IsReady())
            {
                await _engine.NewGame();
            }
        }

        public async Task<Move> GetBestMove()
        {
            return new Move(await _engine.GetBestMove());
        }

        public async Task<Move> GetBestMove(int timeMs)
        {
            return new Move(await _engine.GetBestMove(timeMs));
        }

        public async Task SetPosition(string fen)
        {
            await _engine.SetPosition(fen);
        }

        public async Task SetPosition(string[] moves)
        {
            await _engine.SetPosition(moves);
        }

        public async Task SetOption(string key, string value) // Idea: Option struct with override ToString()?
        {
            await _engine.SetOption(key, value);
        }

        public async Task<Dictionary<int, string[]>> GetPV()
        {
            return await _engine.GetPV();
        }

        public void Dispose()
        {
            _engine.Dispose();
            GC.SuppressFinalize(this);
        }

        ~StockfishService()
        {
            Dispose();
        }
    }
}
