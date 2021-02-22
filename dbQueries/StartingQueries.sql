use restaurantdb;

insert into dishes(Name, Description, Chef, Calories, Tastiness, CreatedAt, UpdatedAt)
values("first Name", "The first Dish", "First Chef Name", 140, 4, now(), now()),
	  ("Second Name", "The Second Dish", "Second Chef Name", 140, 4, now(), now()),
      ("Third Name", "The Third Dish", "Third Chef Name", 140, 4, now(), now()),
      ("Fourth Name", "The Fourth Dish", "Fourth Chef Name", 140, 4, now(), now()),
      ("Fifth Name", "The Fifth Dish", "Fifth Chef Name", 140, 4, now(), now());
