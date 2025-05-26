using AP2.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PetController : ControllerBase
{
    private readonly IPetRepository _repo;
    public PetController(IPetRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Pet>> Get() =>
        Ok(_repo.GetAllAsync());

    [HttpGet("{id}")]
    public ActionResult<Pet> GetById(int id)
    {
        var pet = _repo.GetByIdAsync(id);
        return pet is null ? NotFound() : Ok(pet);
    }

    [HttpPost]
    public ActionResult<Pet> Post(Pet pet)
    {
        var novoPet = _repo.AddAsync(pet);
        return CreatedAtAction(nameof(GetById), new { id = novoPet.Id }, novoPet);
    }

    [HttpPut("{id}")]
    public ActionResult<Pet> Put(int id, Pet pet)
    {
        if (id != pet.Id)
            return BadRequest();

        var petAtualizado = _repo.UpdateAsync(id, pet);
        return petAtualizado is null ? NotFound() : Ok(petAtualizado);
    }

    [HttpDelete("{id}")]
    public ActionResult<Pet> Delete(int id)
    {
        var petDeletado = _repo.DeleteAsync(id);
        return petDeletado is null ? NotFound() : Ok(petDeletado);
    }
}