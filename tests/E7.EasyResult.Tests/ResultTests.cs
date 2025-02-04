﻿using E7.EasyResult.Errors;
using E7.EasyResult.Tests.Responses;
using FluentAssertions;

namespace E7.EasyResult.Tests;

public class ResultTests
{
    [Fact]
    public void Success_ShouldCreateSuccessfulResult()
    {
        var result = Result.Success();

        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Error.Should().BeNull();
    }

    [Fact]
    public void Failure_ShouldCreateFailedResult()
    {
        var error = new ElementNotFoundError();
        var result = Result.Failure(error);

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(error);
    }

    [Fact]
    public void ImplicitConversionFromError_ShouldCreateFailedResult()
    {
        var error = new ElementNotFoundError();
        Result result = error;

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(error);
    }

    [Fact]
    public void IsErrorType_ShouldReturnTrueForMatchingErrorType()
    {
        var error = new ElementNotFoundError();
        var result = Result.Failure(error);

        result.IsErrorType(ErrorType.NotFoundRule).Should().BeTrue();
    }

    [Fact]
    public void IsErrorType_ShouldReturnFalseForNonMatchingErrorType()
    {
        var error = new ElementNotFoundError();
        var result = Result.Failure(error);

        result.IsErrorType(ErrorType.BusinessRule).Should().BeFalse();
    }

    [Fact]
    public void ToString_ShouldReturnSuccessStringForSuccessfulResult()
    {
        var result = Result.Success();
        result.ToString().Should().Be("Success");
    }

    [Fact]
    public void ToString_ShouldReturnFailureStringForFailedResult()
    {
        var error = new ElementNotFoundError();
        var result = Result.Failure(error);

        result.ToString().Should().Be($"Failure: {error}");
    }
}