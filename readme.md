# Bad Apple circuit

## How to use

1. use ffmpeg to convert the video to a series of images
(`ffmpeg -i .\video.mp4 -r 8 -s 8x8 ./frames/%5d.png`)

2. run the converter (`dotnet run --project converter`)

3. import frames.bin into the ROM

4. ???

5. profit
