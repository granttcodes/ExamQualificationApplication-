# Exam Qualification Application

A simple console application that tells a student whether they qualify to sit their exam, based on a weighted average of their coursework marks.

## What It Does

The idea behind this project is straightforward: universities often set a minimum weighted average a student needs before they're allowed into the exam room. This app automates that check.

It asks the user for four marks, applies the correct weighting to each, and works out whether the final average clears the 50% cutoff.

| Assessment      | Weight |
|-----------------|--------|
| Test 1          | 30%    |
| Test 2          | 50%    |
| Assignment 1    | 10%    |
| Project         | 10%    |

- **Weighted average of 50 or higher** → qualifies to write the exam
- **Weighted average below 50** → does not qualify

All input is validated — if you type something that isn't a number, or a number outside the 0–100 range, the app will ask again rather than crashing or producing a nonsense result.

### Example Run

```
======================================
       EXAM QUALIFICATION APP
======================================

Enter Test 1 mark: 65
Enter Test 2 mark: 58
Enter Assignment 1 mark: 72
Enter Project mark: 80

======================================
Weighted average: 63.70%
Result: The student qualifies to write the exam.
======================================
```

## Running It with Docker

This project is built with .NET 8 and packaged as a Docker image, so you don't need the .NET SDK installed to run it — just Docker.

### Prerequisites

- [Docker](https://docs.docker.com/get-docker/) installed and running on your machine

### 1. Pull the image from Docker Hub

```bash
docker pull yourdockerhubusername/examqualificationapp
```

### 2. Run it

Because this is a console app that reads keyboard input, it needs to be run **interactively**. Don't skip the `-it` flags — without them, the container won't be able to see what you type, and it'll just hang.

```bash
docker run -it yourdockerhubusername/examqualificationapp
```

### 3. Enter the marks

Follow the on-screen prompts. Enter each mark as a number between 0 and 100, and the app will do the rest.

## Building the Image Yourself (Optional)

If you'd rather build from source than pull the pre-built image:

```bash
git clone https://github.com/granttcodes/ExamQualificationApplication.git
cd ExamQualificationApplication
docker build -t examqualificationapp .
docker run -it examqualificationapp
```

## How the Image Is Built

The Dockerfile uses a two-stage build to keep the final image lean:

1. **Build stage** — uses the full .NET 8 SDK image to restore dependencies and publish a release build.
2. **Runtime stage** — copies only the published output into a much smaller .NET 8 runtime image, which is what actually ships and runs.

## Tech Stack

- C# / .NET 8
- Docker (multi-stage build)

