WIP.

# Zotero -> BibLaTeX Exporter

This reimplements the main feature of [Better BibTeX for Zotero](https://retorque.re/zotero-better-bibtex/).

This CLI utility directly read the `zotero.sqlite` file in **read-only** mode and produce a BibLaTex file beside a configuration file.

## Rational

I used [Better BibTeX for Zotero](https://retorque.re/zotero-better-bibtex/) to complete my bachelor thesis, but I don't like it for various of reasons:

* Feature creeping. Too many features for a single maintainer project.
* Slow. Zotero uses SQLite as backend and I only have hundreds of items, so producing the `.bib` file should take absolutely no time. (Zotero's JavaScript API is slow?)
* The auto exporting has a noticeable delay.
* Manual saving isn't convenient.
* 3rd party plugin without much restriction is a risk.
* Too many configuration options.
  * No obvious way of syncing configuration between machines.
  * No obvious way to use different configuration for different projects.

## Tech Notes

```sh
fd -e sql -X sqlfluff fix
dotnet format
```

SQL style -> https://handbook.gitlab.com/handbook/enterprise-data/platform/sql-style-guide/

## LICENSE

[GPL-3.0-or-later](https://spdx.org/licenses/GPL-3.0-or-later.html)
