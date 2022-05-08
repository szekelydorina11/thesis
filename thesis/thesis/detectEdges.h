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

    DetectEdges();
	static Mat preProcessing(Mat img);
    static vector<Point> getContours(Mat image, Mat imgResized);
    static void drawPoints(vector<Point> points, Scalar color, Mat imgResized);
    static double distanceBetweenPoints(Point a, Point b);
    static pair<Point, Point> getLineTwoPoints(vector<Point>);
    static vector<Point> reorder(vector<Point> points);
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

//class detectedges
//{
//    public:
//        detectedges();
//    
//        static void loadimage();
//
//};


    //0
    //circle(imgResized, contours[0][0], 10, Scalar(0, 0, 255), FILLED);
    //cout << "contours[0][0]: " << contours[0][0] << "\n";
    //cout << "contours[0].size(): " << contours[0].size() << "\n";
    //int i = contours[0].size() - 1;
    ////circle(imgResized, contours[0][i], 10, Scalar(255, 0, 0), FILLED);
    ////circle(imgResized, contours[0][1], 10, Scalar(0, 0, 255), FILLED);
    //putText(imgResized, to_string(1), contours[0][1], FONT_HERSHEY_PLAIN, 2, Scalar(0, 0, 255), 4);
    ////circle(imgResized, contours[0][2], 10, Scalar(0, 0, 255), FILLED);
    //putText(imgResized, to_string(2), contours[0][2], FONT_HERSHEY_PLAIN, 2, Scalar(0, 0, 255), 4);
    ////circle(imgResized, contours[0][3], 10, Scalar(0, 0, 255), FILLED);
    //putText(imgResized, to_string(3), contours[0][3], FONT_HERSHEY_PLAIN, 2, Scalar(0, 0, 255), 4);
    ////circle(imgResized, contours[0][4], 10, Scalar(0, 0, 255), FILLED);
    //putText(imgResized, to_string(4), contours[0][4], FONT_HERSHEY_PLAIN, 2, Scalar(0, 255, 0), 4);
    ////circle(imgResized, contours[0][5], 10, Scalar(0, 0, 255), FILLED);
    //putText(imgResized, to_string(5), contours[0][5], FONT_HERSHEY_PLAIN, 2, Scalar(255, 0, 255), 4);
    //putText(imgResized, to_string(6), contours[0][6], FONT_HERSHEY_PLAIN, 2, Scalar(0, 255, 255), 4);
    //putText(imgResized, to_string(7), contours[0][7], FONT_HERSHEY_PLAIN, 2, Scalar(255, 255, 255), 4);

    //
    //cout << "contours[0][contours[0].size()]: " << contours[0][i] << "\n";

    //1
    //circle(imgResized, contours[1][0], 10, Scalar(0, 255, 0), FILLED);
    //circle(imgResized, contours[1][contours[1].size()], 20, Scalar(0, 255, 0), FILLED);
    //
    ////2
    //circle(imgResized, contours[2][0], 10, Scalar(255, 0, 0), FILLED);
    //
    //circle(imgResized, contours[3][0], 10, Scalar(0, 255, 255), FILLED);
    //