using Microsoft.AspNetCore.Mvc;
using NurserySystem.Application.DTOs;
using NurserySystem.Application.Interfaces;
using NurserySystem.Domain.Entities;

namespace NurserySystem.Web.Controllers;

public class LevelsController : Controller
{
    private readonly ILevelRepository _levelRepository;

    public LevelsController(ILevelRepository levelRepository)
    {
        _levelRepository = levelRepository;
    }

    public async Task<IActionResult> Index()
    {
        var levels = await _levelRepository.GetAllAsync();
        var levelDtos = levels.Select(l => new LevelDto
        {
            Id = l.Id,
            NameAr = l.NameAr,
            NameEn = l.NameEn,
            Order = l.Order,
            ClassRoomsCount = 0
        });

        return View(levelDtos);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateLevelDto model)
    {
        if (ModelState.IsValid)
        {
            var level = new Level
            {
                NameAr = model.NameAr,
                NameEn = model.NameEn,
                Order = model.Order
            };

            await _levelRepository.AddAsync(level);
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var level = await _levelRepository.GetByIdAsync(id.Value);
        if (level == null) return NotFound();

        return View(level);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Level model)
    {
        if (id != model.Id) return NotFound();

        if (ModelState.IsValid)
        {
            model.UpdatedAt = DateTime.UtcNow;
            await _levelRepository.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var level = await _levelRepository.GetByIdAsync(id.Value);
        if (level == null) return NotFound();

        return View(level);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var level = await _levelRepository.GetByIdAsync(id);
        if (level != null)
        {
            await _levelRepository.DeleteAsync(level);
        }

        return RedirectToAction(nameof(Index));
    }
}
