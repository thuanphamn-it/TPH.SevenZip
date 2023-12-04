#! /bin/bash

target_file_path=$1
destination_file_path=$2
password=$3

7z a "$destination_file_path" -p$password -mhe -t7z -mx0 -v1000M -bb0 "$target_file_path"
# 7z a "$destination_file_path" -p$password -mhe -t7z -mx0 -v1000M -bb0 -sdel "$target_file_path" 

exit 0