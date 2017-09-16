using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TradingManager.Model;

namespace TradingManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly TMDbContext _context;

        public HomeController(TMDbContext context)
        {
            _context = context;    
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transactions.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactions = await _context.Transactions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (transactions == null)
            {
                return NotFound();
            }

            return View(transactions);
        }

        // GET: Home/Create
        public IActionResult Create(string transactionId)
        {
            if (transactionId == null)
                ViewBag.transactionId = Guid.NewGuid();
            else
                ViewBag.transactionId = transactionId;
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TransactionId,TransactionTime,TransactionType,OrderType,Price,Amount,Leverage,TranscationFee,UserId,Exchange,Symbol")] Transactions transactions)
        {
            transactions.TransactionTime = DateTime.Now;
            transactions.TranscationFee = 0;
            transactions.Leverage = 1;

            if (ModelState.IsValid)
            {
                _context.Add(transactions);
                await _context.SaveChangesAsync();
                if (transactions.TransactionType == TransactionType.Margin)
                    return RedirectToAction("Create", new { transactionId = transactions.TransactionId });
                return RedirectToAction("Index");
            }
            return View(transactions);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactions = await _context.Transactions.SingleOrDefaultAsync(m => m.Id == id);
            if (transactions == null)
            {
                return NotFound();
            }
            return View(transactions);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TransactionId,TransactionTime,TransactionType,OrderType,Price,Amount,Leverage,TranscationFee,UserId,Exchange,Symbol")] Transactions transactions)
        {
            if (id != transactions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionsExists(transactions.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(transactions);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactions = await _context.Transactions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (transactions == null)
            {
                return NotFound();
            }

            return View(transactions);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactions = await _context.Transactions.SingleOrDefaultAsync(m => m.Id == id);
            _context.Transactions.Remove(transactions);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TransactionsExists(int id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}
