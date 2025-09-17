using System;
using Microsoft.Extensions.Configuration;
using Library.Infrastructure.Data;
using Library.ApplicationCore;
using Library.ApplicationCore.Entities;
using Xunit;

public class GetLoanTest
{
    private readonly ILoanRepository _mockLoanRepository;
    private readonly JsonLoanRepository _jsonLoanRepository;
    private readonly IConfiguration _configuration;
    private readonly JsonData _jsonData;

    public GetLoanTest()
    {
        // Build configuration for JsonData
        _configuration = new ConfigurationBuilder()
            .Build();

        _jsonData = new JsonData(_configuration);
        _jsonLoanRepository = new JsonLoanRepository(_jsonData);

        // For completeness, but not used for JsonLoanRepository tests
        _mockLoanRepository = null!;
    }

    [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns loan when loan ID exists")]
    public async Task GetLoan_ReturnsLoan_WhenLoanIdExists()
    {
        // Arrange
        int existingLoanId = 1; // This ID exists in Loans.json

        // Act
        var actualLoan = await _jsonLoanRepository.GetLoan(existingLoanId);

        // Assert
        Assert.NotNull(actualLoan);
        Assert.Equal(existingLoanId, actualLoan!.Id);
    }
    [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns null when loan ID does not exist")]
    public async Task GetLoan_ReturnsNull_WhenLoanIdDoesNotExist()
    {
        // Arrange
        int nonExistingLoanId = 999; // This ID does not exist in Loans.json

        // Act
        var actualLoan = await _jsonLoanRepository.GetLoan(nonExistingLoanId);

        // Assert
        Assert.Null(actualLoan);
    }
}