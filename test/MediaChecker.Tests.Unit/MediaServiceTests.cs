using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MediaChecker.Interfaces;
using MediaChecker.Services;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace MediaChecker.Tests.Unit;

public class MediaServiceTests
{
    private readonly MediaService _sut;
    private readonly IFileService _fileService = Substitute.For<IFileService>();
    private readonly ILogger<MediaService> _logger = Substitute.For<ILogger<MediaService>>();

    public MediaServiceTests()
    {
        _sut = new MediaService(_logger, _fileService);
    }
    
    [Fact]
    public async Task GetAllMediasAsync_ShouldNotBeNullAndNotBeEmpty_WhenAtLeastOneFileIsPresent()
    {
        // Arrange
        var expectedFiles = new[]
        {
            new FileInfo(Path.GetTempFileName())
        };
        
        _fileService.GetAllFilesAsync().Returns(new Task<IEnumerable<FileInfo>>(() => expectedFiles));

        // Act
        var medias = await _sut.GetAllMediasAsync();
    
        // Assert
        var enumerable = medias.ToList();
        enumerable.Should().NotBeNull();
        enumerable.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task GetAllMediasAsync_ShouldReturnEmptyList_WhenNoFilesExist()
    {
        // Arrange
        _fileService.GetAllFilesAsync().Returns(new Task<IEnumerable<FileInfo>>(Enumerable.Empty<FileInfo>));
        
        // Act
        var medias = await _sut.GetAllMediasAsync();

        // Assert
        medias.Should().BeEmpty();
    }
    
    [Fact]
    public async Task GetAllMediasAsync_ShouldContains3Files_WhenThereIs3Files()
    {
        // Arrange
        var expectedFiles = new[]
        {
            new FileInfo(Path.GetTempFileName()),
            new FileInfo(Path.GetTempFileName()),
            new FileInfo(Path.GetTempFileName())
        };
        
        _fileService.GetAllFilesAsync().Returns(new Task<IEnumerable<FileInfo>>(() => expectedFiles));
        
        // Act
        var medias = await _sut.GetAllMediasAsync();
        
        // Assert
        medias.Should().HaveCount(3);
    }
}