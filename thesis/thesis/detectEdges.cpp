#include "detectedges.h"
#include <stdio.h>
#include <iostream>
#include <opencv2/core/core.hpp>
#include <opencv2/core/cuda.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/imgproc/imgproc.hpp>
#include <opencv2/imgproc.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgcodecs.hpp>

using namespace cv;
using namespace std;

Mat imgGray, imgBlur, imgCanny, imgDil;

float w = 420, h = 596;


DetectEdges::DetectEdges() {}

Mat DetectEdges::preProcessing(Mat img)
{
    cvtColor(img, imgGray, COLOR_BGR2GRAY);
    GaussianBlur(imgGray, imgBlur, Size(3, 3), 3, 0);
    Canny(imgBlur, imgCanny, 25, 75);
    Mat kernel = getStructuringElement(MORPH_RECT, Size(3, 3));
    dilate(imgCanny, imgDil, kernel);
    //erode(imgDil, imgErode, kernel);
    return imgDil;
    //return imgBlur;
}

vector<Point> DetectEdges::getContours(Mat image, Mat imgResized) {

    vector<vector<Point>> contours;
    vector<Vec4i> hierarchy;

    findContours(image, contours, hierarchy, RETR_EXTERNAL, CHAIN_APPROX_SIMPLE);
    for (int i = 0; i < hierarchy.size(); ++i) {
        cout << "hierarchy: " << hierarchy[i] << "\n";
    }
    vector<Point> biggest;
    int maxArea = 0;

    cout << "contours.size(): " << contours.size() << "\n";
    /*if (contours.size() > 1)
    {
        pair<Point, Point> p;
        for (int i = 0; i < contours.size(); ++i) {
            cout << "contours: " << contours[i] << "\n";
            p = getLineTwoPoints(contours[i]);

            circle(imgResized, p.first, 10, Scalar(0, 0, 255), FILLED);
            circle(imgResized, p.second, 10, Scalar(0, 0, 255), FILLED);
            line(imgResized, p.first, p.second, Scalar(0, 255, 0), 2);
        }
    }
    else
    {*/
    //drawPoints(contours[0], Scalar(0, 255, 255));

    //drawContours(image, contours, -1, Scalar(255, 0, 255), 2);
    vector<vector<Point>> conPoly(contours.size());
    vector<Rect> boundRect(contours.size());


    for (int i = 0; i < contours.size(); i++)
    {
        int area = (int)contourArea(contours[i]);
        //cout << area << endl;

        //if (area > 1000)
        {
            float peri = (float)arcLength(contours[i], true);
            approxPolyDP(contours[i], conPoly[i], 0.02 * peri, true);

            if (area > maxArea && conPoly[i].size() >= 3) {

                drawContours(imgResized, conPoly, i, Scalar(255, 0, 255), 5);
                biggest = conPoly[i];
                maxArea = area;
            }
            //drawContours(imgOriginal, conPoly, i, Scalar(255, 0, 255), 2);
            //rectangle(imgOriginal, boundRect[i].tl(), boundRect[i].br(), Scalar(0, 255, 0), 5);
        }
    }
    //}

    if (maxArea == 0)
    {
        pair<Point, Point> p;
        for (int i = 0; i < contours.size(); ++i) {
            cout << "contours: " << contours[i] << "\n";
            p = getLineTwoPoints(contours[i]);

            circle(imgResized, p.first, 10, Scalar(0, 0, 255), FILLED);
            circle(imgResized, p.second, 10, Scalar(0, 0, 255), FILLED);
            line(imgResized, p.first, p.second, Scalar(0, 255, 0), 2);
        }
    }

    return biggest;
}

void DetectEdges::drawPoints(vector<Point> points, Scalar color, Mat imgResized)
{
    cout << "points.size()" << points.size() << "\n";
    for (int i = 0; i < points.size(); i++)
    {
        //circle(imgResized, points[i], 10, color, FILLED);
        //putText(imgResized, to_string(i), points[i], FONT_HERSHEY_PLAIN, 4, color, 4);
        if (i == ((int)points.size() - 1))
            cv::line(imgResized, points[i], points[0], color, 2);
        else
            cv::line(imgResized, points[i], points[i + 1], color, 2);
    }
}

double DetectEdges::distanceBetweenPoints(Point a, Point b)
{
    return sqrt(pow(a.x - b.x, 2) +
        pow(a.y - b.y, 2));
}

pair<Point, Point> DetectEdges::getLineTwoPoints(vector<Point> points)
{
    Point a = points[0];
    Point b = points[1];
    double longest = distanceBetweenPoints(a, b);
    double act = longest;
    for (int i = 0; i < points.size(); ++i)
    {
        for (int j = 2; j < points.size(); ++j)
        {
            if (a != b)
            {
                act = distanceBetweenPoints(points[i], points[j]);
                if (act > longest)
                {
                    longest = act;
                    a = points[i];
                    b = points[j];
                    //cout << "longest: " << longest << " a: " << a << " b: " << b << "\n";
                }
            }
        }
    }
    pair<Point, Point> p{ a, b };
    cout << " a: " << a << " b: " << b << "\n";
    return p;
}

vector<Point> DetectEdges::reorder(vector<Point> points)
{
    vector<Point> newPoints;
    vector<int>  sumPoints, subPoints;

    for (int i = 0; i < 4; i++)
    {
        sumPoints.push_back(points[i].x + points[i].y);
        subPoints.push_back(points[i].x - points[i].y);
    }

    newPoints.push_back(points[min_element(sumPoints.begin(), sumPoints.end()) - sumPoints.begin()]); // 0
    newPoints.push_back(points[max_element(subPoints.begin(), subPoints.end()) - subPoints.begin()]); //1
    newPoints.push_back(points[min_element(subPoints.begin(), subPoints.end()) - subPoints.begin()]); //2
    newPoints.push_back(points[max_element(sumPoints.begin(), sumPoints.end()) - sumPoints.begin()]); //3

    return newPoints;
}




//#include <stdio.h>
//#include <iostream>
//#include <opencv2/core/core.hpp>
//#include <opencv2/core/cuda.hpp>
//#include <opencv2/highgui/highgui.hpp>
//#include <opencv2/imgproc/imgproc.hpp>
//#include <opencv2/imgproc.hpp>
//#include <opencv2/highgui.hpp>
//#include <opencv2/imgcodecs.hpp>

//detectedges::detectedges()
//{
//}
//
//void detectedges::loadimage(){
//    Mat im = imread("d:\\egyetem\\thesis\\bgr_frame.jpg"); //cv::imreadmodes
//    //Mat im = imread("d:\\egyetem\\playground\\scan.png"); //cv::imreadmodes
//    //Mat im = imread("d:\\egyetem\\playground\\lena.jpg"); //cv::imreadmodes
//    //Mat im = imread("d:\\egyetem\\playground\\lena.png"); //cv::imreadmodes
//    //Mat im = imread("d:\\egyetem\\playground\\xray.jpeg"); //cv::imreadmodes
//    
//    //uint8_t* pixelptr = (uint8_t*)im.data;
//    /*int cn = im.channels();
//    scalar_<uint8_t> bgrpixel;
//
//    for (int i = 0; i < im.rows; i++)
//    {
//        uint8_t* rowptr = (uint8_t*)im.row(i);
//        for (int j = 0; j < im.cols; j++)
//        {
//            vec3b bgrpixel = im.at<vec3b>(i, j);
//
//            bgrpixel.val[0] = rowptr[j * cn + 0]; // b
//            bgrpixel.val[1] = rowptr[j * cn + 1]; // g
//            bgrpixel.val[2] = rowptr[j * cn + 2]; // r
//            */
//            
//            
//            /*bgrpixel.val[0] = pixelptr[i * im.cols * cn + j * cn + 0]; // b
//            bgrpixel.val[1] = pixelptr[i * im.cols * cn + j * cn + 1]; // g
//            bgrpixel.val[2] = pixelptr[i * im.cols * cn + j * cn + 2]; // r
//            */
//
//            /*
//            std::cout << bgrpixel.val[0] << " ";// = pixelptr[i * im.cols * cn + j * cn + 0]; // b
//            std::cout << bgrpixel.val[1] << " ";// = pixelptr[i * im.cols * cn + j * cn + 1]; // g
//            std::cout << bgrpixel.val[2] << "\n";// = pixelptr[i * im.cols * cn + j * cn + 2]; // r
//             do something with bgr values...
//        }
//    }*/
//    int x = 100, y = 50;
//    unsigned char* p = im.ptr(y, x); // y first, x after
//    p[0] = 0;   // b
//    p[1] = 0;   // g
//    p[2] = 255; // r
//
//    uint8_t* pixelptr = (uint8_t*)im.data;
//    int cn = im.channels();
//    Scalar_<uint8_t> bgrpixel;
//
//    std::cout << "im.data: " << im.data << "\n" << "im.size: " << im.size() << "\n";
//    
//    Mat im_resized;
//    resize(im, im_resized, Size(), 0.5, 0.5);
//    std::cout << "im_resized.size: " << im_resized.size() << "\n";
//
//    for (int c = 0; c < im.cols; c++)
//    {
//        for (int r = 0; r < im.rows; r++)
//        {
//            Vec3b pixel = im.at<Vec3b>(c, r);
//            int blue = (int)pixel[0];// = 233;
//            int green = (int)pixel[1];// = 18;
//            int red = (int)pixel[2];// = 29;
//
//            std::cout << "pixel at position (x, y) : (" << c << ", " << r << ") = " <<
//                im.at<Vec3b>(c, r) << "< " << red << ", " << green << ", " << blue << ">" << std::endl;
//            
//
//            //im.at<Vec3b>(c, r) = v;
//            /*
//            bgrpixel.val[0] = pixelptr[i * im.cols * cn + j * cn + 0]; // b
//            bgrpixel.val[1] = pixelptr[i * im.cols * cn + j * cn + 1]; // g
//            bgrpixel.val[2] = pixelptr[i * im.cols * cn + j * cn + 2]; // r
//            */
//            Vec3b intensity = im.at<Vec3b>(c, r);
//            for (int k = 0; k < im.channels(); k++)
//            {
//                uchar col = intensity.val[k];
//            
//            }
//        }
//    }
//
//
//    //namedwindow("image");
//    imshow("image", im);
//    imshow("image2", im_resized);
//
//    waitKey(0);
//}
//
//////////////////////////////////////////////

//Mat DetectEdges::preProcessing(Mat img)
//{
//    cvtColor(img, imgGray, COLOR_BGR2GRAY);
//    //GaussianBlur(imGray, imBlur, Size(3, 3), 3, 0);
//    //Canny(imBlur, imCanny, 25, 75);
//    //Mat kernel = getStructuringElement(MORPH_RECT, Size(3, 3));
//    //dilate(imCanny, imDil, kernel);
//    //erode(imgDil, imgErode, kernel);
//    //return imDil;
//    return imgGray;
//}
/*
vector<Point> getContours(Mat image) {

    vector<vector<Point>> contours;
    vector<Vec4i> hierarchy;

    findContours(image, contours, hierarchy, RETR_EXTERNAL, CHAIN_APPROX_SIMPLE);
    //drawContours(img, contours, -1, Scalar(255, 0, 255), 2);
    vector<vector<Point>> conPoly(contours.size());
    vector<Rect> boundRect(contours.size());

    vector<Point> biggest;
    int maxArea = 0;

    for (int i = 0; i < contours.size(); i++)
    {
        int area = contourArea(contours[i]);
        //cout << area << endl;

        string objectType;

        if (area > 1000)
        {
            float peri = arcLength(contours[i], true);
            approxPolyDP(contours[i], conPoly[i], 0.02 * peri, true);

            if (area > maxArea && conPoly[i].size() == 4) {

                //drawContours(imgOriginal, conPoly, i, Scalar(255, 0, 255), 5);
                biggest = { conPoly[i][0],conPoly[i][1] ,conPoly[i][2] ,conPoly[i][3] };
                maxArea = area;
            }
            //drawContours(imgOriginal, conPoly, i, Scalar(255, 0, 255), 2);
            //rectangle(imgOriginal, boundRect[i].tl(), boundRect[i].br(), Scalar(0, 255, 0), 5);
        }
    }
    return biggest;
}

void drawPoints(vector<Point> points, Scalar color)
{
    for (int i = 0; i < points.size(); i++)
    {
        circle(imgOriginal, points[i], 10, color, FILLED);
        putText(imgOriginal, to_string(i), points[i], FONT_HERSHEY_PLAIN, 4, color, 4);
    }
}

vector<Point> reorder(vector<Point> points)
{
    vector<Point> newPoints;
    vector<int>  sumPoints, subPoints;

    for (int i = 0; i < 4; i++)
    {
        sumPoints.push_back(points[i].x + points[i].y);
        subPoints.push_back(points[i].x - points[i].y);
    }

    newPoints.push_back(points[min_element(sumPoints.begin(), sumPoints.end()) - sumPoints.begin()]); // 0
    newPoints.push_back(points[max_element(subPoints.begin(), subPoints.end()) - subPoints.begin()]); //1
    newPoints.push_back(points[min_element(subPoints.begin(), subPoints.end()) - subPoints.begin()]); //2
    newPoints.push_back(points[max_element(sumPoints.begin(), sumPoints.end()) - sumPoints.begin()]); //3

    return newPoints;
}

Mat getWarp(Mat img, vector<Point> points, float w, float h)
{
    Point2f src[4] = { points[0],points[1],points[2],points[3] };
    Point2f dst[4] = { {0.0f,0.0f},{w,0.0f},{0.0f,h},{w,h} };

    Mat matrix = getPerspectiveTransform(src, dst);
    warpPerspective(img, imgWarp, matrix, Point(w, h));

    return imgWarp;
}*/



