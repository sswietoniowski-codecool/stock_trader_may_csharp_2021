# StockTrader

## Story

Stock trading refers to the buying and selling of shares in a particular company; if you own the stock, you own a piece of the company. Trading is a very stressful profession.
One thing is important regarding stock trading: [If what you are doing right now is not making you money, why not try the opposite approach?](http://www.dstockmarket.com/the-funniest-trading-story-i-have-ever-heard-that-will-make-you-laugh.html)
One of your friends decided to invest some money into promising stocks. But of course, he needs to know
what are the options. As a fellow developer, he simply started to write a stock trading application.
He is not so sure whether it's good. He wants to cover his work with unit tests,
and follow higher standards, but he only has limited time for this project.
So he turns to you for help.
Now you have to review and refactor his code to make it testable, and guess what, easily extendable
for a better future development experience.

You don't hesitate and dive into some industry standard unit testing to make his code fabulous.

## What are you going to learn?

- Understand dependency injection design pattern.
- Create lousily coupled classes.
- Use mocks, stubs (test doubles) objects.
- Use a mocking framework.
- Generating test reports.

## Tasks

1. Implement a refactor logging functionality for a more future-proof version.
    - The `FileLogger` is not a singleton.
    - A new logger type can be defined, for example, DBLogger, without changing the previously created logger class.

2. Make `RemoteURLReader` easy to mock.
    - The `ReadFromUrl()` method can be mocked by NSubstitude.

3. Refactor the Stock API service.
    - There are no hidden dependencies in `StockAPIService`. The caller knows of all outer dependencies of the class when creating an object from it.
    - When calling the `GetPrice()` method, if the given symbol does not appear in the response, an `ArgumentException` is thrown.

4. Refactor the `Trader` class.
    - There are no hidden dependencies in `Trader`. The caller knows of all outer dependencies of the class when creating an object from it.

5. Cover the `StockAPIService` class with unit tests.
    - The `GetPrice()` method has a unit test for existing symbols. In this case the test returns true.
    - The `GetPrice()` method has a unit test for non-existing symbols. In this case, an `ArgumentException` is thrown.
    - The `GetPrice()` method has a unit test for the case when `RemoteURLReader` throws any exceptions.
    - The `GetPrice()` method has a unit test for the case when the received response has an invalid JSON format. In this case, a `JsonReaderException` is thrown.

6. Cover the `Trader` class with unit tests
    - The `Buy()` method has a unit test for passing a lower bid than the price. In this case, the test returns false.
    - The `Buy()` method has a unit test for passing a higher bid than the price. In this case the test returns true.
    - The `Buy()` method has a unit test for passing a non-existing symbol. In this case, it throws an `ArgumentException`.

## General requirements

- The following dependency injections are applied.
- There are no static variables or methods.
- Each class has only one instance, which is created in `Main`.
- Unit tests do not perform any real remote calls or file IO operations.

## Hints

- Mock out remote calls and file IOs. Do not use unit tests for this.
- TBD


## Background materials

- <i class="far fa-exclamation"></i> [Dependency injection](project/curriculum/materials/competencies/enterprise-architecture/dependency-injection.md.html)
- <i class="far fa-exclamation"></i> [Mocking](project/curriculum/materials/pages/general/mocking.md)
- <i class="far fa-exclamation"></i> [Unit tests, stubs, mocks quick overview by Martin Fowler](https://www.youtube.com/watch?v=sEFhB71tmPM)
- <i class="far fa-exclamation"></i> [NSubstitute mocking framework](https://nsubstitute.github.io/)

