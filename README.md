# Disruptor port in C# #

This is a disruptor port in C# for proof of concept- NOT Production ready!

### What is this repository for? ###

This is a proof of concept disruptor written in C# for testing out ring buffer concept.

### Description ###

#### Disruptor.cs ####

Wire up Reader and Writer

#### Barrier.cs and Cursor.cs ####

Barrier acts as the data store for Writer and Reader's cursors. Provides the writer if it can write to the slots.

#### Reader.cs ####

Is started by a task and starts reading using the Consumer helper. 

#### Consumer.cs ####

Helper for reader to consume messages off the ring buffer. 


#### Writer.cs ####

Writes to ring buffer using Reserve and Commit helpers so that it safely handles writes.


### How do I get set up? ###

* Visual Studio 2015 
* Clone this repo.

### References

[LMAX Disruptor](https://github.com/LMAX-Exchange/disruptor)

[Disruptor explained](https://martinfowler.com/articles/lmax.html)

[Disruptor in Go](https://github.com/smartystreets/go-disruptor)