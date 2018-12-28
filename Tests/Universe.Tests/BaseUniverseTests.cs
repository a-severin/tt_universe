using System;
using System.Data.SQLite;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;

namespace Universe.Tests
{
    [ExcludeFromCodeCoverage]
    public class BaseUniverseTests
    {
        protected IUniverse Universe(UniverseSources source)
        {
            switch (source)
            {
                case UniverseSources.InMemo:
                    return new Universe.Model.InMemory.Universe();
                case UniverseSources.SQLite:
                    return new Universe.Model.Sqlite.SqliteUniverse(new SQLiteConnection("Data Source=:memory:")
                        .OpenAndReturn());
                default:
                    throw new ArgumentException($"Unexpected {nameof(source)} value: {source}");
            }
        }
    }

    public enum UniverseSources
    {
        InMemo,
        SQLite
    }
}