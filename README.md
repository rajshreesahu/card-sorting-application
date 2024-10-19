# ***Sort My Deck***

## Overview
The **Sort My Deck Application** is a full-stack solution built using C# **.NET Core** for the API and **React** for the UI. It simulates a card game where you are given a random deck of cards, and you need to sort them based on predefined rules. This project incorporates modern UI design principles using **Material UI** in React, along with **Jest** for comprehensive unit testing.

## Problem Statement
In this card game, the goal is to sort the cards given to you according to specific rules:
1. **Special Cards** like 4T, 2T, ST, PT, and RT must be sorted first, in that exact order.
2. **Normal Cards** (like 3C, 10H, etc.) are sorted by suit in the order: Diamonds, Spades, Clubs, and Hearts, and by rank from 2 to Ace.

This application simulates the sorting of the cards using a full-stack approach, combining API logic and an interactive web interface.

## Project Structure
  - **Backend: .NET Core API**
    - The API handles the business logic for sorting the cards.
    - The sorting is done according to the given priority for special and normal cards.
  - **Frontend: React with Material UI**
    - The UI is built using **React** and designed with **Material UI**, offering a modern and responsive user interface.
    - The cards are displayed and sorted interactively, with a visually appealing design.
  - **Unit Testing:**
    - **API:** The API logic is thoroughly tested with unit tests using **XUnit**.
    - **UI:** The UI is tested using **Jest**, ensuring that the components behave as expected and the card sorting logic works correctly on the frontend.
  - **Azure Deployment:**
    - The API is hosted using **Azure Web Apps**, enabling scalable and efficient backend operations.

## Features

### API (Backend):

  - **Card Sorting Logic:**
    - The API accepts a list of cards as input and sorts them according to the rules:
      - Special Cards (4T, 2T, ST, PT, RT) are sorted first.
      - Normal Cards are sorted by suit and rank.
  - **RESTful API:** Built using ASP.NET Core, the API is RESTful and efficient.
  - **Unit Tested:** The API is tested with **XUnit** to ensure the sorting logic functions correctly.

### UI (Frontend):

  - **React:** The frontend is built using the React framework, leveraging its component-based architecture.
  - **Material UI:** The design is enhanced with Material UI for a clean, modern, and responsive user interface.
  - **Card Display and Sorting:** Cards are dynamically displayed and can be sorted using the API logic. Users can visualize the sorting process on the webpage.
  - **Testing:** The UI is tested using **Jest**, ensuring component reliability and functional correctness.
  - **Enhanced Features:** The project utilizes advanced React features such as hooks, state management, and component-based architecture for a seamless user experience.

## API Documentation

### API Endpoint

**POST** /api/cards/sort
  - **Request Body** (JSON):
      - Input: A list of strings representing the cards to be sorted.
         - [
          "3C", "JS", "2D", "PT", "10H", "KH", "8S", "4T", "AC", "4H", "RT"
          ]

  - **Response** (JSON):
    - Output: A list of strings representing the sorted cards.
        - [
          "4T", "PT", "RT", "2D", "8S", "JS", "3C", "AC", "4H", "10H", "KH"
          ]

  - **API Endpoint:** The API can be accessed at https://card-sorting-api-cygmfsf7ewh4g7ad.southeastasia-01.azurewebsites.net/api/cards/sort

## UI Features
  The UI of the application is a user-friendly interface built using **React.js** and styled with **Material UI**. Users can input a deck of unsorted cards, and the sorted deck is displayed     interactively on the page.

  - **UI Website:** The live application can be accessed at: https://agreeable-mud-00917d300.5.azurestaticapps.net/

## Project Highlights
  - **Separation of Concerns:** The project is split into distinct API and UI sections, ensuring clean architecture and maintainability.
  - **Code Reusability:** Helper functions (e.g., for extracting rank and suit) are abstracted for reusability across the project.
  - **Comprehensive Unit Testing:** Both the API and UI are covered by unit tests, ensuring that changes to the codebase do not introduce regressions.
  - **Responsive UI:** The UI is fully responsive and styled using Material UI, ensuring that it looks great on all devices.
  - **Modern Development Stack:** The project uses the latest versions of .NET Core and React to ensure a modern development experience.
  - **Scalability:** The system is designed to be extensible, allowing for future features and changes without major code refactoring.
  - **Error Handling:** Improved error handling on both the API and UI sides for better user feedback.
  - **Logging:** Enabling **Application Insights to Azure** to log the API data.
  - **SOLID Principles:** The application follows SOLID design principles, ensuring that the code is flexible, amintainable, and scalable.
  - **Deployment Process:** The deployment process is fully automated via GitHub Actions, with separate workflows for the UI and backend, ensuring seamless CI/CD.

## Conclusion
The Sort My Deck Application showcases a full-stack implementation of a card sorting game. With a focus on clean code, maintainability, and modern technologies, the project is designed to be both functional and easy to extend. The use of React, Material UI, and .NET Core ensures a scalable, responsive, and modern solution.
