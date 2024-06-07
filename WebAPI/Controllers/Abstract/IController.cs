using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public interface IController<T>
{
    IActionResult GetAll();
    IActionResult GetById(int id);
    IActionResult Add(T entity);
    IActionResult Update(T entity);
    IActionResult Delete(T entity);
}