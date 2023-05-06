using Microsoft.AspNetCore.Mvc;
using Mongo.DataManager;
using Mongo.Models;

namespace Mongo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly MongoDataManager _dataManager;

        public UserController(MongoDataManager dataManager) => 
            _dataManager = dataManager;

        [HttpGet]
        public async Task<List<User>> Get() =>
        await _dataManager.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            var user = await _dataManager.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User newUser)
        {
            await _dataManager.CreateAsync(newUser);

            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, User updatedUser)
        {
            var user = await _dataManager.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            updatedUser.Id = user.Id;

            await _dataManager.UpdateAsync(id, updatedUser);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _dataManager.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            await _dataManager.RemoveAsync(id);

            return NoContent();
        }
    }
}