﻿using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.Plugins.InMemory;

public class SuggestionInMemoryRepository : ISuggestionRepository
{
    private List<Suggestion> _courses;

    public SuggestionInMemoryRepository()
    {
        _courses = new List<Suggestion>()
        {
            new Suggestion { Id = 1, SuggestionName = "Suggestion1", SuggestionDesc = "Read a book."},
            new Suggestion { Id = 2, SuggestionName = "Suggestion2", SuggestionDesc = "Make a list." },
            new Suggestion { Id = 3, SuggestionName = "Suggestion3", SuggestionDesc = "Take notes."},
            new Suggestion { Id = 4, SuggestionName = "Suggestion4", SuggestionDesc = "Start early." }
        };
    }

    public async Task<IEnumerable<Suggestion>> GetSuggestionsByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_courses);

        return _courses.Where(x => x.SuggestionName.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public Task AddSuggestionAsync(Suggestion course)
    {
        if (_courses.Any(x => x.SuggestionName.Equals(course.SuggestionName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;
        
        var maxId = _courses.Max(x => x.Id);
        course.Id = maxId + 1;

        _courses.Add(course);

        return Task.CompletedTask;
    }

     public async Task<Suggestion> GetSuggestionByIdAsync(int courseId)
    {
        var c = _courses.First(x => x.Id == courseId);
        var newSuggestion = new Suggestion
        {
            Id = c.Id,
            SuggestionName = c.SuggestionName,
            SuggestionDesc = c.SuggestionDesc
        };

        return await Task.FromResult(newSuggestion);
    }

     public Task UpdateSuggestionAsync(Suggestion course)
        {

            // we are not allowing two different courses to have the same name, so we have to check to make sure
            if (_courses.Any(x => x.Id != course.Id &&
                x.SuggestionName.Equals(course.SuggestionName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var crs = _courses.FirstOrDefault(x => x.Id == course.Id);
            if (crs != null)
            {
                crs.SuggestionName = course.SuggestionName;
                crs.SuggestionDesc = course.SuggestionDesc;
            }

            return Task.CompletedTask;
        }
}
