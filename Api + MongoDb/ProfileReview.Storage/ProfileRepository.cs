using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ProfileReview.Services.Models;
using ProfileReview.Storage.Interfaces;

namespace ProfileReview.Storage;

public class ProfileRepository(IConfiguration configuration) : IProfileRepository
{
    private readonly string _connectionString = configuration.GetConnectionString("MongoDbConnection") ?? throw new ArgumentNullException();
    private readonly string _database = configuration.GetSection("MongoDatabase").Value ?? throw new ArgumentNullException();

    public async Task<Profile?> GetByIdAsync(string id)
    {
        // Is dit oké om aan de hand van een Id te zoeken?
        var result = await GetCollection().Find(p => p.Id.ToString() == id).FirstOrDefaultAsync();
        return result;
    }

    public async Task<Profile> CreateAsync(Profile profile)
    {
        var coll = GetCollection();
        await coll.InsertOneAsync(profile);
        // Hoe vraag je hier op een propere manier het zopas aangemaakte profile op?
        var createdProfile = (await coll.FindAsync(p => p.Name == profile.Name && p.Email == profile.Email && p.Description == profile.Description)).Single();
        return createdProfile;
    }

    public async Task UpdateAsync(Profile profile)
    {
        await GetCollection().ReplaceOneAsync(p => p.Id == profile.Id, profile);
    }

    private IMongoCollection<Profile> GetCollection()
    {
        var client = new MongoClient(_connectionString);

        var db = client.GetDatabase(_database);
        if (db is null)
            throw new Exception("Database not found");

        var coll = db.GetCollection<Profile>("testcollection");
        if (coll is null)
            throw new Exception("Collection not found");

        return coll;
    }
}