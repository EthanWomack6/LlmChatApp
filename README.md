# LlmChatApp
Chat with database and different features, meant to be modular to fit the needs of whoever wants to use it.
Broad overview: TBD but most likely to be an agent sandbox/personal assistant, i just want to customize the UI by myself pretty much

Features: 
 - eventually a multi agent framework that automatically switches depending on where i am in the ui (chat segment, vs coding vs something else)
 - RAG or vector database for stored context, have an agent be able to put project details in said database instead of keeping it in context
 - ai models with an orchestrator to fulfill 3 roles: Coding, a personal assistant, and 








 USe cases: 
 - personal assistant 
 1. scheduling, general talking, etc
 2. general agentic tasks, searching internet, recipes, querries to check different things (check price on digimon cards
  i mention, bring up a report once a day)
  3. remind me of calendar appointments coming up
  4. 














  Design flow: 
  1. dashboard, possibly a login just in case that i want different users to use it
  2. "how can i help you today" with a selection of things (assistant being the default, it has a chat window but allows you to change the topic), has link to daily reports in a small feed
  3. dedicated interfaces for settings on each differnet llm


  Personal assitant: (first to implement, as itll be the first thing to interact with)
  - main chat window, with a modular project board on left side of screen, can have a recipe board, a time sensistive notifications, brainstorming, etc 
  - has a bar on the left similar to the big llm models that you can see past chats in. 
  - text box at the bottom, obviously, being able to upload images will be ideal, but might not be possible depending on the speed i want on this model
  ideally, the personal assitant model can run on my laptop, but if it doesnt then so be it, ill just run an app to my phone so i can use it on the go
- it will have saved chats, that'll be easy to implement
- have a tab for all generated/uploaded files and images
- SEARCH A SEARCH FUNCTION 
- schedule a task, have a dashboard for all tasks with settings for frequency, (ie, every night it checks the web for x digimon cards, then tells me their price)
- open integration for the coder model to add functionality ( ie, coder can add a new section to the personal assistant tools)




  coding assistant: 
  - project board instead of chat windows, but with one generic "clearing after every session" one that is for basic scripting
  - ideally the agent will perform its coding, and fill out its readme/implementation steps, etc for review later
  - doesnt need to show the code, but will ask for permission before doing most things 
- give access to tools to allow it to check minecraft stuff. 
- ability to search internet and store documentation on technologies (ie, save documentation on specific libraries/minecraft mods)
- eventually i want integration for a model to be able to poke around in my minecraft server stuff and fix issues and whatnot, but that can be in coder
- ill do all github stuff myself, since ill probably use it for basic implementations of stuff (implement some html and javascript boilerplate, or this niche specific idea i have)

  roelplay: 
  - specific character windows, settings page to store information abou the character so that I can open a different character profile (persistent chat history)
  and its able to continue where i left off as well as change between characters without blending them
