import subprocess
import os

# Absolute path to your RoleplayService project folder
project_path = r"C:\Users\OSAdmin\OneDrive\UTM\Year_4\PAD\Roleplay\src\RoleplayService"

# Change working directory to the project folder
os.chdir(project_path)

# Restore dependencies
print("Restoring dependencies...")
subprocess.run(["dotnet", "restore"], check=True)

# Build the project
print("Building project...")
subprocess.run(["dotnet", "build"], check=True)

# Run the project on a specific URL
print("Running RoleplayService on http://localhost:5001")
subprocess.run(["dotnet", "run", "--urls", "http://localhost:5001"], check=True)
