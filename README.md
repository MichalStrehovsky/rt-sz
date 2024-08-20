# runtime-size

This repo aids in measuring native AOT size impact of pull requests in the dotnet/runtime repo.

Simply create a new issue whose title is a pull request number in the dotnet/runtime repo. The body of the issue can be empty, it doesn't matter. In about 30 minutes, you'll get a response from the bot and the issue will be auto closed.

To retrigger the bot, reopen the issue.

You can attach labels to the issues to publish with specific options. For example, add `EventSourceSupport=true` label to run publish with `-p:EventSourceSupport=true`.
