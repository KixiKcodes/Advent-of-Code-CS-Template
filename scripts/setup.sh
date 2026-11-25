#!/usr/bin/env bash
set -euo pipefail

script_dir="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd -P)"
template_root="$(cd -- "$script_dir/.." && pwd -P)"

if ! command -v dotnet >/dev/null 2>&1; then
    printf 'dotnet is not installed or not on PATH.\n' >&2
    exit 1
fi

if [[ ! -f "$template_root/.template.config/template.json" ]]; then
    printf 'Could not find the .NET template at %s.\n' "$template_root" >&2
    exit 1
fi

dotnet new install "$template_root" --force

mkdir -p "$HOME/.local/bin"
install -m 755 "$script_dir/aoc" "$HOME/.local/bin/aoc"

printf 'Installed the aoc command to %s/.local/bin and the aoc-year template for this user.\n' "$HOME"
