# Online Learning Platform

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Database Relationships](#database-relationships)
- [Architecture](#architecture)
- [Technologies Used](#technologies-used)
- [Entity Framework (EF) Core](#entity-framework-ef-core)
- [Getting Started](#getting-started)
- [Docker](#docker)
- [Contributing](#contributing)

## Introduction

This project is an Online Learning Platform that allows instructors to create courses, and students to enroll in courses, watch lessons, and track their progress. It's built using .NET 7 and PostgreSQL as the database.

## Features

- Instructors can create courses and lessons.
- Students can enroll in courses.
- Students can complete lessons and track their progress.
- Passwords are securely hashed using BCrypt.
- Authentication is handled through JWT Bearer tokens.
- Custom authorization filters are implemented.
- Containerized using Docker for easy deployment.

## Database Relationships

The project's database includes the following entities with the following relationships:

### User
- One-to-many relationship with CreatedCourses (Instructors).
- Many-to-many relationship with EnrolledCourses (Students).

### Course
- One-to-many relationship with Students.
- One-to-many relationship with Lessons.
- Many-to-many relationship with EnrolledCourses.

### Lesson
- Belongs to a Course.

### Enrollment
- Points to a Course.
- Points to a Student.
- Tracks progress with CompletedLessons.

## Architecture

The project follows an Onion Architecture with the following layers:
- Domain
- Data Access
- Services
- API

Inversion of Dependency Injection is used to decouple dependencies between layers. Interfaces are placed in the Domain layer, and other layers depend on these abstractions.

## Technologies Used

- .NET 7
- PostgreSQL
- Docker
- BCrypt (Password hashing)
- JWT Bearer (Authentication)
- Custom Authorization Filters

## Entity Framework (EF) Core

Entity Framework (EF) Core is used as the Object-Relational Mapping (ORM) framework to work with the database. The database schema is managed and queried using EF Core migrations.

## Getting Started

To get started with the project, follow these steps:

    1. Clone the repository: `git clone https://github.com/otavioadamis/LearningPlataform`
    2. Navigate to the project directory.
    3. Build and run the project.

## Docker

The project can be containerized using Docker. A Dockerfile and Docker Compose configuration are provided.

To run the application and PostgreSQL in Docker containers:

    1. Build the Docker images: `docker-compose build`
    2. Start the containers: `docker-compose up`

## Contributing

Contributions to this project are welcome. Feel free to open issues and submit pull requests to help improve the platform.

