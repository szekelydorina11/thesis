#include <stdio.h>
#include <iostream>
#include <core.hpp>
#include <opencv2/core/cuda.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/imgproc/imgproc.hpp>
#include <opencv2/imgproc.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgcodecs.hpp>

using namespace cv;

class DetectEdges {
    DetectEdges();

    void loadImage();
};

void loadImage() {
    Mat im = imread("image.jpg", CV_LOAD_IMAGE_COLOR);
    namedWindow("image");
    imshow("image", im);
    waitKey(0);
}