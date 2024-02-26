#!/bin/bash

html_file='build/WebGL/WebGL/index.html'
if test -f $html_file; then
  SHORT_TI=`echo $TITLE_NAME | sed -e 's/^.*\///'`
  echo "File exists. Changin title to ${SHORT_TI}"
  sudo chmod 666 $html_file
  cat $html_file | sed -e "s/<title>Unity WebGL Player.*<\/title>/<title>${SHORT_TI}<\/title>/" > tmp.html
  cp tmp.html $html_file
fi
