#pragma once
#ifndef DETECTEDGES_H
#define DETECTEDGES_H

#include <stdio.h>
#include <iostream>
#include <vector>
#include <opencv2/core/core.hpp>
#include <opencv2/core/cuda.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/imgproc/imgproc.hpp>
#include <opencv2/imgproc.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgcodecs.hpp>

using namespace cv;
using namespace std;

class DetectEdges {
public:
    static String imageName;

    DetectEdges();
	static Mat imageProcessing(Mat img);
    static vector<Point> getContours(Mat image, Mat imgResized);
    static void drawPoints(vector<Point> points, Scalar color, Mat imgResized);
    static double distanceBetweenPoints(Point a, Point b);
    static pair<Point, Point> getLineTwoPoints(vector<Point>);
    static vector<Point> reorder(vector<Point> points);
    static int saveImage(Mat image, String process, String name);
    static void setImageName(String path);
    static String getImageName();
};


/*
Mat getWarp(Mat img, vector<Point> points, float w, float h)
{
    Point2f src[4] = { points[0],points[1],points[2],points[3] };
    Point2f dst[4] = { {0.0f,0.0f},{w,0.0f},{0.0f,h},{w,h} };

    Mat matrix = getPerspectiveTransform(src, dst);
    warpPerspective(img, imgWarp, matrix, Point(w, h));

    return imgWarp;
}
*/
#endif // !DETECTEDGES_H