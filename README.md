# AG.UrlHelpers

[![NuGet](https://img.shields.io/nuget/v/AG.UrlHelpers.svg)](https://www.nuget.org/packages/AG.UrlHelpers)
[![Build](https://github.com/AGLogicStudio/UrlHelpers/actions/workflows/ci.yml/badge.svg)](https://github.com/AGLogicStudio/UrlHelpers/actions)
[![License](https://img.shields.io/github/license/AGLogicStudio/UrlHelpers)](LICENSE)

**AG.UrlHelpers** is a minimal, cross-platform URL composition utility library that simplifies combining and normalizing URL segments in .NET applications.

---

## ✨ Features

- ⚡ Cleanly concatenate URLs while handling slashes and query fragments
- 🧹 Eliminates redundant delimiters and trailing separators
- 💻 Built with zero dependencies and focused on predictable behavior
- 🧪 Fully unit tested with xUnit

---

## 📦 Installation

```bash
dotnet add package AG.UrlHelpers
or via .csproj
<PackageReference Include="AG.UrlHelpers" Version="1.0.0" />
```
## 🚀 Usage
```
using AG.UrlHelpers;

string url = UrlPath.Combine(
    "https://example.com/",
    "api/",
    "/v1/",
    "resource?type=json#top"
);
// Result: https://example.com/api/v1/resource?type=json#top
