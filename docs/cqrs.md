# What is CQRS in simple terms?

Every operation is either:

COMMAND → changes data (Create, Update, Delete)
QUERY → reads data (Get, List)

Each has its own class, own handler, own validation.
Nothing is mixed together.
