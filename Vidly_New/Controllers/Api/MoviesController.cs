using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly_New.Dtos;
using Vidly_New.Models;

namespace Vidly_New.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// GET /api/Movies
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetMovies()
        {
            var Movies = _context.Movies.ToList();


            List<MovieDto> MovieDtos = Mapper.Map<List<Movie>, List<MovieDto>>(Movies);


            return Ok(MovieDtos);
        }

        /// <summary>
        /// GET /api/Movies/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetMovies(int id)
        {

            var Movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (Movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(Movie));
        }

        /// <summary>
        /// POST /api/Movies/
        /// </summary>
        /// <param name="MovieDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto MovieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var Movie = Mapper.Map<MovieDto, Movie>(MovieDto);
            _context.Movies.Add(Movie);
            _context.SaveChanges();

            MovieDto.Id = Movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + Movie.Id), MovieDto);
        }

        /// <summary>
        /// PUT /api/Movies/1
        /// </summary>
        /// <param name="id"></param>
        /// <param name="MovieDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto MovieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            var MovieToUpdate = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (MovieToUpdate == null)
                return NotFound();

            Mapper.Map<MovieDto, Movie>(MovieDto, MovieToUpdate);

            _context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// DELETE /api/Movies/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {

            var MovieToDelete = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (MovieToDelete == null)
                return NotFound();

            _context.Movies.Remove(MovieToDelete);
            _context.SaveChanges();
            return Ok();
        }
    }
}
