# Continuous Integration Report

## Repository and evidence status

The repository is not yet published: this workspace has no Git remote and GitHub CLI is not installed or authenticated. Therefore, a GitHub repository URL and screenshots of hosted Actions runs are not available yet. The workflow and test suite are ready for publication. The pass and failure results below were verified locally with the same solution build and test commands used by CI.

## Workflow configuration

The workflow at `.github/workflows/ci.yml` runs on every push, pull request, and manual dispatch. It uses an Ubuntu runner, checks out the source, installs .NET 10, builds `RandomCardGenerator.slnx` in Release configuration, and runs its tests without rebuilding. It uploads any generated TRX test results even when a test fails. The workflow requests read-only repository-content permission.

## Build and test stages

The build stage compiles the application and test project, also restoring their NuGet dependencies. The test stage executes five xUnit tests covering Ace, Ten, King, and numbered-card image URL mappings, plus the supported suit and rank range returned by `Card.RandomCard()`.

## Execution analysis

**Successful baseline:** The test project built successfully and all five tests passed. After the defect check, the production mapping was restored and the full suite passed again (5 passed).

**Deliberate defect:** The Ace rank mapping was temporarily changed from `A` to `2`. The Ace-of-Hearts test failed with an expected-versus-actual URL string mismatch, identifying `ImageUrl_MapsAceOfHearts` as the failing test. This confirms that an incorrect card-image mapping is detected by the automated test suite. The defect was then removed; it is not present in the submitted application.

## Captured failing-test evidence

With the Ace rank deliberately changed to `2`, the local run produced 1 failure and 4 successes. The failing test was `CardGenerator.Tests.CardTests.ImageUrl_MapsAceOfHearts`; it expected `https://deckofcardsapi.com/static/img/AH.png` and received `https://deckofcardsapi.com/static/img/2H.png`.

These are local test-runner results, not GitHub-hosted Actions executions. To complete hosted evidence, push the clean baseline and capture the successful Actions run, then temporarily change the Ace mapping, push that change and capture the failed run, and finally restore the mapping and push the fix. Add the repository URL and screenshots of each run here after publication.