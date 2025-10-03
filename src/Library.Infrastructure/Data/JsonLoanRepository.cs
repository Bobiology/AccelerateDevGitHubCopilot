using Library.ApplicationCore;
using Library.ApplicationCore.Entities;

namespace Library.Infrastructure.Data;

public class JsonLoanRepository : ILoanRepository
{
    private readonly JsonData _jsonData;

    public JsonLoanRepository(JsonData jsonData)
    {
        _jsonData = jsonData;
    }

    public async Task<Loan?> GetLoan(int id)
    {
        await _jsonData.EnsureDataLoaded();

        return _jsonData.Loans!
            .Where(loan => loan.Id == id)
            .Select(loan => _jsonData.GetPopulatedLoan(loan))
            .FirstOrDefault();
    }

    public async Task UpdateLoan(Loan loan)
    {
        var loans = _jsonData.Loans!;
        var index = loans.FindIndex(l => l.Id == loan.Id);

        if (index >= 0)
        {
            loans[index] = loan;

            await _jsonData.SaveLoans(loans);
            await _jsonData.LoadData();
        }
    }
}