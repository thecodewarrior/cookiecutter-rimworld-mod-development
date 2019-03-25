import os

#About is always made
os.makedirs("{{cookiecutter.mod_name}}/Defs", exist_ok=True)
os.makedirs("{{cookiecutter.mod_name}}/Patches", exist_ok=True)
os.makedirs("{{cookiecutter.mod_name}}/Languages", exist_ok=True)
os.makedirs("{{cookiecutter.mod_name}}/Sounds", exist_ok=True)
os.makedirs("{{cookiecutter.mod_name}}/Textures", exist_ok=True)