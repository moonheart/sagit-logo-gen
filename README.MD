# Sagit Logo Generator

## How to use (Windows)

1. Download this project and goto `GenLogo` folder.
2. Edit these 5 bmp files, do not change filename or format.
3. Run `GenLogo.exe` and you get `logo_new.img`.
4. flash through fastboot `fastboot flash logo logo_new.img`
5. Enjoy!

## How to use (Linux&Unix)

1. Download this project and goto `GenLogo` folder.
2. Edit these 5 bmp files, do not change filename or format.
3. Run `python genlogo.py` and you get `logo_new.img` (python3).
4. flash through fastboot `fastboot flash logo logo_new.img`
5. Enjoy!

## 使用说明

1. 下载 `GenLogo` 文件夹。
2. 编辑其中的五张bmp文件，不要更改文件名或者文件格式。
3. 运行 `GenLogo.exe` 会生成一个 `logo_new.img` 文件。
4. 使用命令 `fastboot flash logo logo_new.img` 刷入手机。
5. 重启即可看到效果。