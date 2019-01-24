using AutoMapper;
using NermeenVidly.DTOs;
using NermeenVidly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NermeenVidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        ApplicationDbContext _Context;

        public MoviesController()
        {
            _Context = new ApplicationDbContext();
        }
        // GET /api/Movies
        public IHttpActionResult GetMovies()
        {
            var Movies = _Context.Movies;
            if (Movies == null)
                return NotFound();
            return Ok(Movies.ToList().Select(Mapper.Map<Movie, MoviesDto>));
        }
        // GET /api/Movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var MovieInDB = _Context.Movies.SingleOrDefault(C => C.Id == id);

            if (MovieInDB is null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MoviesDto>(MovieInDB));
        }

        // Save /api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MoviesDto MovieDto)
        {
            if (MovieDto is null)
                return BadRequest();

            Movie Movie = Mapper.Map<MoviesDto, Movie>(MovieDto);
            _Context.Movies.Add(Movie);
            _Context.SaveChanges();
            MovieDto.Id = Movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + Movie.Id), MovieDto);
        }

        // PUT /api/Movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MoviesDto Movie)
        {
            var MovieInDB = _Context.Movies.SingleOrDefault(C => C.Id == id);

            if (MovieInDB is null)
                return NotFound();

            Mapper.Map(Movie, MovieInDB);
            _Context.SaveChanges();

            return Ok();
        }

        // Delete /api/Movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var MovieInDB = _Context.Movies.SingleOrDefault(C => C.Id == id);

            if (MovieInDB is null)
                return NotFound();
            _Context.Movies.Remove(MovieInDB);
            _Context.SaveChanges();

            return Ok();
        }
    }
}
