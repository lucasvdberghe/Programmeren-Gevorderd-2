using System;
using EventPlanner.Shared;
using EventPlanner.Storage.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace EventPlanner.Storage;

public class AuditRepository(IConfiguration configuration) : IAuditRepository
{
    private readonly string _connectionString = configuration.GetConnectionString("EventPlannerMongoDb") ?? throw new ArgumentNullException();
    private readonly string _mongoDbDatabase = configuration.GetSection("AuditTrailDatabase").Value ?? throw new ArgumentNullException();

    public async Task AddEntryAsync(string subject, string action, string oldValue, string newValue)
    {
        var newAuditEntry = new AuditEntry
        {
            Subject = subject,
            Action = action,
            OldValue = oldValue,
            NewValue = newValue
        };

        await GetCollection().InsertOneAsync(newAuditEntry);
    }

    public async Task<IEnumerable<AuditEntry>> GetAuditTrailAsync(string? subject, string? action)
    {
        var filter = Builders<AuditEntry>.Filter.Empty;

        if (!string.IsNullOrWhiteSpace(subject))
        {
            filter &= Builders<AuditEntry>.Filter.Eq(a => a.Subject, subject);
        }

        if (!string.IsNullOrWhiteSpace(action))
        {
            filter &= Builders<AuditEntry>.Filter.Eq(a => a.Action, action);
        }

        return await GetCollection().Find(filter).ToListAsync();
    }

    private IMongoCollection<AuditEntry> GetCollection()
    {
        var client = new MongoClient(_connectionString);

        var db = client.GetDatabase(_mongoDbDatabase);
        if (db is null)
            throw new Exception("Database not found");

        var coll = db.GetCollection<AuditEntry>("auditcollection");
        if (coll is null)
            throw new Exception("Collection not found");

        return coll;
    }
}
