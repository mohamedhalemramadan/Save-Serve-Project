using Microsoft.AspNetCore.Mvc;
using NurserySystem.Application.DTOs;
using NurserySystem.Application.Interfaces;
using NurserySystem.Domain.Entities;

namespace NurserySystem.Web.Controllers;

public class ClassesController : Controller
{
    private readonly IClassRoomRepository _classRoomRepository;
    private readonly ILevelRepository _levelRepository;

    public ClassesController(IClassRoomRepository classRoomRepository, ILevelRepository levelRepository)
    {
        _classRoomRepository = classRoomRepository;
        _levelRepository = levelRepository;
    }

    public async Task<IActionResult> Index()
    {
        var classRooms = await _classRoomRepository.GetAllAsync();
        var classDtos = classRooms.Select(c => new ClassRoomDto
        {
            Id = c.Id,
            NameAr = c.NameAr,
            NameEn = c.NameEn,
            LevelId = c.LevelId,
            LevelName = c.Level?.NameAr,
            MaxCapacity = c.MaxCapacity,
            CurrentCount = 0 // Should be calculated from children count
        });

        return View(classDtos);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Levels = await _levelRepository.GetAllAsync();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateClassRoomDto model)
    {
        if (ModelState.IsValid)
        {
            var classRoom = new ClassRoom
            {
                NameAr = model.NameAr,
                NameEn = model.NameEn,
                LevelId = model.LevelId,
                MaxCapacity = model.MaxCapacity
            };

            await _classRoomRepository.AddAsync(classRoom);
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Levels = await _levelRepository.GetAllAsync();
        return View(model);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var classRoom = await _classRoomRepository.GetByIdAsync(id.Value);
        if (classRoom == null) return NotFound();

        ViewBag.Levels = await _levelRepository.GetAllAsync();
        return View(classRoom);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ClassRoom model)
    {
        if (id != model.Id) return NotFound();

        if (ModelState.IsValid)
        {
            model.UpdatedAt = DateTime.UtcNow;
            await _classRoomRepository.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Levels = await _levelRepository.GetAllAsync();
        return View(model);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var classRoom = await _classRoomRepository.GetByIdAsync(id.Value);
        if (classRoom == null) return NotFound();

        return View(classRoom);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var classRoom = await _classRoomRepository.GetByIdAsync(id);
        if (classRoom != null)
        {
            await _classRoomRepository.DeleteAsync(classRoom);
        }

        return RedirectToAction(nameof(Index));
    }
}
