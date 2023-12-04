#! /bin/bash

target_file_path=$1
destination_path=$2
password=$3

7z e -p$password -aos  -o"$destination_path" "$target_file_path"

exit 0