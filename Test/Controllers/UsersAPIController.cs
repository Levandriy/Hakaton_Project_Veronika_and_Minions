using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test;
using Test.Data;

namespace Test.Controllers
{
    /// <summary>
    /// API контроллер для модели пользователя
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAPIController : ControllerBase
    {
        private readonly TestContext _context;

        public UsersAPIController(TestContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Выбрать всех пользователей из базы данных проекта, то есть базы данных, созданной согласно DBcontext (см папку Data, TestContext.cs)
        /// </summary>
        /// <returns>Список пользователей</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        /// <summary>
        /// Выбрать пользователя по ID из базы данных проекта
        /// </summary>
        /// <param name="id">ID пользователя, которого нужно найти</param>
        /// <returns>Пользователя</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        /// <summary>
        /// Изменить пользователя
        /// </summary>
        /// <param name="id">Код пользователя</param>
        /// <param name="user">Новые данные (соответсвуют модели), код должен быть тем же</param>
        /// <returns>Сообщение об успешном обновлении или ошибку</returns>
        [HttpPut("{id}")] 
        public async Task<ActionResult<User>> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Content($"Данные пользователя {user.Name} обновлены");
        }

        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="user">Данные пользователя (соответствуют модели)</param>
        /// <returns>Результат выполнения, данные, которые были добавлены</returns>
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'TestContext.User'  is null.");
          }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="id">Код пользователя, который нужно удалить</param>
        /// <returns>Сообщение об успешном удалении, либо ошибку</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Content($"Пользователь {user.Id} удалён");
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
