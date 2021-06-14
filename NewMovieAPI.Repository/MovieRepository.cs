using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewMovieAPI.Data;
using NewMovieAPI.Entities;
using NewMovieAPI.Repository.Interfaces;

namespace NewMovieAPI.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;
        public MovieRepository(DataContext context)
        {
            _context = context;
        }

        public async void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var movie = await GetMovie(id);
            _context.Movies.Remove(movie);
            _context.SaveChangesAsync();
        }
        public async void Edit(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovie(int id)
        {
            // first option
            var result = _context.Movies.FirstOrDefault(x => x.Id == id);
            // Dva nacina kako da ga zeme knigu po id
            //var result = _context.Movies.Find(id); 
            // second option
            return result;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var result = _context.Movies.AsEnumerable();
            return result;
        }
        public IEnumerable<Movie> GetMovies2()
        {
            var result = _context.Movies.AsEnumerable();
            return result;
        }
    }
}
