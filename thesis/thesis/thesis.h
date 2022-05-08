#pragma once

#include "detectEdges.h"
#include <stdio.h>
#include <vector>
#include <bitset>
#include <cstddef>

#define DllExport __declspec( dllexport )

extern "C" DllExport int imageProcess(char* path);

//DllExport vector<uchar> imageProcess(char* path);