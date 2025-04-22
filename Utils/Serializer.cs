using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ChessApp.Models.Moves;

namespace ChessApp.Utils
{
    internal static class Serializer
    {
        private static readonly JsonSerializerOptions options = new() { WriteIndented = true,  DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

        private const string GAMES_PATH = @"..\..\..\data.json";
        private const string CONFIG_PATH = @"..\..\..\config.json";

        private record MoveHistory(LinkedList<string> Moves);
        private record EngineOptions(EngineOption[] Options);

        public static void Write(LinkedList<Move> moves)
        {
            using StreamWriter writer = CreateFile(GAMES_PATH);
            writer.Write(SerializeMoveHistory(moves));
        }

        public static void Write(EngineOption[] engineOptions)
        {
            using StreamWriter writer = CreateFile(CONFIG_PATH);
            writer.Write(SerializeOptions(engineOptions));
        }

        public static string SerializeMoveHistory(LinkedList<Move> moves)
        {
            MoveHistory moveData = new(
                Moves: new LinkedList<string>(moves.Select(move => move.ToString()))
            );

            return JsonSerializer.Serialize(moveData, options);
        }

        public static string SerializeOptions(EngineOption[] engineOptions)
        {
            EngineOptions optionData = new(
                Options: [.. engineOptions.Where(option => !string.IsNullOrWhiteSpace(option.Name) && !string.IsNullOrWhiteSpace(option.Value))]
            );
            return JsonSerializer.Serialize(optionData, options);
        }

        public static StreamWriter CreateFile(string path)
        {
            return File.CreateText(path);
        }

        public static LinkedList<Move>? DeserializeMoveHistory()
        {
            string json;
            if (!File.Exists(GAMES_PATH))
            {
                CreateFile(GAMES_PATH);
            }
            using (StreamReader reader = File.OpenText(GAMES_PATH))
            {
                json = reader.ReadToEnd();
            }
            if (string.IsNullOrWhiteSpace(json) || string.IsNullOrEmpty(json))
            {
                return null;
            }

            MoveHistory? moveData = JsonSerializer.Deserialize<MoveHistory>(json, options);

            if (moveData == null)
                return null;

            LinkedList<Move> moves = new(moveData.Moves.Select(moveString => new Move(moveString)));
            return moves;
        }

        public static EngineOption[]? DeserializeOptions()
        {
            string json;
            if (!File.Exists(CONFIG_PATH))
            {
                CreateFile(CONFIG_PATH);
            }
            using (StreamReader reader = File.OpenText(CONFIG_PATH))
            {
                json = reader.ReadToEnd();
            }
            if (string.IsNullOrWhiteSpace(json) || string.IsNullOrEmpty(json))
            {
                return null;
            }

            EngineOptions? engineOptionsWrapper = JsonSerializer.Deserialize<EngineOptions>(json, options);
            return engineOptionsWrapper?.Options;
        }

        public static void ClearMoves()
        {
            using StreamWriter writer = CreateFile(GAMES_PATH);
            writer.Write(string.Empty);
        }
    }
}
