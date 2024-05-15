# Surprise Calendar - Promotional Game 

The Surprise Calendar application is a web-based platform where visitors can interact with a virtual calendar containing hidden prizes. Users can scratch open squares on the calendar to reveal whether they have won a prize.

## Features


- **Scratchable Squares**: The application presents users with a grid of scratchable squares, each potentially containing a prize.
- **Prizes**: One square contains the main prize of 25000 euros, while 100 other squares contain consolation prizes.
- **User Interaction**: Users can click on a square to reveal whether they have won a prize.
- **State Preservation**: The application preserves the state of opened squares, allowing users to see which squares have already been scratched by other users.
- **Multiple Users**: Simulated multiple users can interact with the application simultaneously, each with their own session and state.


### 1. Setup Instructions

#### A. Backend API (ASP.NET Core)



1. Clone this repository to your local machine.

2. **Database Setup**: 
    Execute the database creation script ('DatabaseCreation') to create the SurpriseCalendar database and tables.  
3. Build and run the API Project.

#### B. Frontend Angular Application

1. Navigate to 'SurpriseCalendarFrontend' folder.
2. Intall dependencies - [npm install]
3. Start the Angular developement server - [ng serve]
4. Open your web browser and navigate to 'http://localhost:4200'.


## Conclusion

The Surprise Calendar application provides an engaging and interactive experience for users, allowing them to scratch squares and potentially win prizes.

