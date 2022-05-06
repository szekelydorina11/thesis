#pragma once

#include "detectEdges.h"
DllExport extern "C" __declspec( dllexport ) int imageProcess(char* path);
#include <stdio.h>
#include <vector>
#include <bitset>
#include <cstddef>


__declspec(dllexport) int imageProcess(char* path);

//DllExport vector<uchar> imageProcess(char* path);