param([string] $migration = 'InitialCreate', $dbtype = 'all')

$env:Path += "	% USERPROFILE % \.dotnet\tools";

# Write-Host "Updating dotnet ef tools"
# dotnet tool update --global dotnet-ef 

$currentPath = Get-Location
$dbtypeSqlServer = 'SqlServer';
$dbtypeSqlite = 'Sqlite';
$dbtypeSqlite = 'MySql';
$dbtypePostgreSQL = 'PostgreSQL';

# Classifiers.Infrastructure.SqlServer
if ($dbtype -eq 'all' -or $dbtype -eq 'SqlServer' ) {
	$componentName = "Classifiers.Infrastructure.SqlServer";
	$componentPath = ".\Classifiers.Infrastructure.SqlServer";
	Set-Location $componentPath
	Write-Host "Generate migration for $componentName"
	dotnet ef migrations add $migration
	Write-Host "Generate SQL-script for $componentName"
	dotnet ef migrations script --idempotent -o "Migrations\$componentName.$migration.sql"
	Set-Location $currentPath
}

# Classifiers.Infrastructure.Sqlite
if ($dbtype -eq 'all' -or $dbtype -eq 'Sqlite' ) {
	$componentName = "Classifiers.Infrastructure.Sqlite";
	$componentPath = ".\Classifiers.Infrastructure.Sqlite";
	Set-Location $componentPath
	Write-Host "Generate migration for $componentName"
	dotnet ef migrations add $migration
	Write-Host "Generate SQL-script for $componentName"
	# --idempotent NOT support
	dotnet ef migrations script -o "Migrations\$componentName.$migration.sql"
	Set-Location $currentPath
}

# Classifiers.Infrastructure.MySql
if ($dbtype -eq 'all' -or $dbtype -eq 'MySql' ) {
	$componentName = "Classifiers.Infrastructure.MySql";
	$componentPath = ".\Classifiers.Infrastructure.MySql";
	Set-Location $componentPath
	Write-Host "Generate migration for $componentName"
	dotnet ef migrations add $migration
	Write-Host "Generate SQL-script for $componentName"
	# --idempotent NOT support
	dotnet ef migrations script --idempotent -o "Migrations\$componentName.$migration.sql"
	Set-Location $currentPath
}

# Classifiers.Infrastructure.PostgreSQL
if ($dbtype -eq 'all' -or $dbtype -eq 'PostgreSQL' ) {
	$componentName = "Classifiers.Infrastructure.PostgreSQL";
	$componentPath = ".\Classifiers.Infrastructure.PostgreSQL";
	Set-Location $componentPath
	Write-Host "Generate migration for $componentName"
	dotnet ef migrations add $migration
	Write-Host "Generate SQL-script for $componentName"
	# --idempotent NOT support
	dotnet ef migrations script --idempotent -o "Migrations\$componentName.$migration.sql"
	Set-Location $currentPath
}
