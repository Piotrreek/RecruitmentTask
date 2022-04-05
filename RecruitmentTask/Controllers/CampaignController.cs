#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Entities;
using RecruitmentTask.Models;

namespace RecruitmentTask.Controllers
{
    public class CampaignController : Controller
    {
        private readonly CampaignDbContext _context;
        public CampaignController(CampaignDbContext context)
        {
            _context = context;
        }

        // GET: Campaign
        public async Task<IActionResult> Index()
        {
            var account = _context.EmeraldAccounts.First();
            ViewData["EmeraldAccount"] = account;
            return View(await _context.Campaigns.ToListAsync());
        }

        // GET: Campaign/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Campaign/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                var account = _context.EmeraldAccounts.First();
                account.Funds -= campaign.CampaignFund;
                if (account.Funds < 0)
                {
                    TempData["NotEnoughMoney"] = "You can't pay that much for this campaign. You do not have enough money at your Emerald account";
                    account.Funds += campaign.CampaignFund;
                    return View(campaign);
                }
                _context.Add(campaign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campaign);
        }

        // GET: Campaign/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var campaign = await _context.Campaigns.FindAsync(id);
            if (campaign == null)
            {
                return NotFound();
            }
            return View(campaign);
        }

        // POST: Campaign/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Keywords,BidAmount,CampaignFund,Status,Town,Radius")] Campaign campaign)
        {
            if (id != campaign.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campaign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampaignExists(campaign.Id))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(campaign);
        }

        // GET: Campaign/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaigns
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campaign == null)
            {
                return NotFound();
            }
            return View(campaign);
        }

        // POST: Campaign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var campaign = await _context.Campaigns.FindAsync(id);
            _context.Campaigns.Remove(campaign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampaignExists(int id)
        {
            return _context.Campaigns.Any(e => e.Id == id);
        }
    }
}
