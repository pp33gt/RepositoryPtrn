To enable Test Project to Access Internals on UnitUnder Test Library
Add
Target Library ->
AssemblyInfo.cs

[assembly: InternalsVisibleTo("RepositoryPtrn.Tests")]


Note: course=full-stack-dot-net-developer-architecture-testing