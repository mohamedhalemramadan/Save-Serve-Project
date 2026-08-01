using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NurserySystem.Application.DTOs;
using NurserySystem.Application.Interfaces;
using NurserySystem.Domain.Entities;

namespace NurserySystem.Web.Controllers;

public class ChildrenController : Controller
{
    private readonly IChildRepository _childRepository;
    private readonly IClassRoomRepository _classRoomRepository;

    public ChildrenController(IChildRepository childRepository, IClassRoomRepository classRoomRepository)
    {
        _childRepository = childRepository;
        _classRoomRepository = classRoomRepository;
    }

    // GET: Children
    public async Task<IActionResult> Index()
    {
        var children = await _childRepository.GetAllAsync();
        var childDtos = children.Select(c => new ChildDto
        {
            Id = c.Id,
            NameAr = c.NameAr,
            NameEn = c.NameEn,
            DateOfBirth = c.DateOfBirth,
            Gender = c.Gender,
            BloodType = c.BloodType,
            MedicalNotes = c.MedicalNotes,
            PhotoPath = c.PhotoPath,
            GuardianId = c.GuardianId,
            GuardianName = c.Guardian?.NameAr,
            GuardianPhone = c.Guardian?.Phone,
            ClassRoomId = c.ClassRoomId,
            ClassRoomName = c.ClassRoom?.NameAr,
            LevelName = c.ClassRoom?.Level?.NameAr
        });

        return View(childDtos);
    }

    // GET: Children/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var child = await _childRepository.GetByIdAsync(id.Value);
        if (child == null) return NotFound();

        var childDto = new ChildDto
        {
            Id = child.Id,
            NameAr = child.NameAr,
            NameEn = child.NameEn,
            DateOfBirth = child.DateOfBirth,
            Gender = child.Gender,
            BloodType = child.BloodType,
            MedicalNotes = child.MedicalNotes,
            PhotoPath = child.PhotoPath,
            GuardianId = child.GuardianId,
            GuardianName = child.Guardian?.NameAr,
            GuardianPhone = child.Guardian?.Phone,
            ClassRoomId = child.ClassRoomId,
            ClassRoomName = child.ClassRoom?.NameAr,
            LevelName = child.ClassRoom?.Level?.NameAr
        };

        return View(childDto);
    }

    // GET: Children/Create
    public async Task<IActionResult> Create()
    {
        ViewBag.ClassRooms = await _classRoomRepository.GetAllAsync();
        return View();
    }

    // POST: Children/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateChildDto model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction(nameof(Index));
        }

        ViewBag.ClassRooms = await _classRoomRepository.GetAllAsync();
        return View(model);
    }

    // GET: Children/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var child = await _childRepository.GetByIdAsync(id.Value);
        if (child == null) return NotFound();

        ViewBag.ClassRooms = await _classRoomRepository.GetAllAsync();
        return View(child);
    }

    // POST: Children/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Child model)
    {
        if (id != model.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                model.UpdatedAt = DateTime.UtcNow;
                await _childRepository.UpdateAsync(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ChildExists(model.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        ViewBag.ClassRooms = await _classRoomRepository.GetAllAsync();
        return View(model);
    }

    // GET: Children/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var child = await _childRepository.GetByIdAsync(id.Value);
        if (child == null) return NotFound();

        return View(child);
    }

    // POST: Children/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var child = await _childRepository.GetByIdAsync(id);
        if (child != null)
        {
            await _childRepository.DeleteAsync(child);
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> ChildExists(int id)
    {
        return await _childRepository.GetByIdAsync(id) != null;
    }
}
