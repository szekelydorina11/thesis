#include "thesis.h"

#include <stdio.h>
#include <vector>
#include <string>
#include <cstddef>
#include <bitset>


int imageProcess(char* path)
{
	DetectEdges::setImageName(path);
	String imageName = DetectEdges::getImageName();

	Mat imgResized, imgThre;
	string process = "";

	//std::string path = "d:\\egyetem\\playground\\xray.jpeg"; imgOriginal = imread(path);
	//std::string path = "d:\\egyetem\\playground\\scan.png"; imgOriginal = imread(path);
	//std::string path = "D:\\Egyetem\\thesis\\paint1.png"; imgOriginal = imread(path);
	//std::string path = "D:\\Egyetem\\thesis\\paint2.png"; imgOriginal = imread(path);
	//std::string path = "D:\\Egyetem\\thesis\\paint3.png"; imgOriginal = imread(path);
	//std::string path = "D:\\Egyetem\\thesis\\paint4.png"; imgOriginal = imread(path);
	//std::string path = "D:\\Egyetem\\thesis\\paint4.2.png"; imgOriginal = imread(path);
	//std::string path = "D:\\Egyetem\\thesis\\paint5.png"; imgOriginal = imread(path);

	//std::string path2 = "D:\\Egyetem\\thesis\\scan1.jpg"; Mat imgOriginal = imread(path2);
	//string path = "D:\\Egyetem\\thesis\\scan2.jpg"; imgOriginal = imread(path);
	
	cout << "path: " << path << "\n";

	Mat imgOriginal = imread(path);
	
	if (imgOriginal.empty())
	{
		std::cout << "Could not read the image: " << path << std::endl;
		return 1;
	}

	double scale = 1.;
	double scaleY = 1.;

	auto imSize = imgOriginal.size();
	double aspectRatio = imSize.aspectRatio();

	double longEdge = 800;
	double shortEdge = 800 / aspectRatio;
	if (aspectRatio > 1) {
		scale = longEdge / imSize.width;
	}
	else {
		scale = longEdge / imSize.height;
	}


	cout << "imgOriginal.size(): " << imgOriginal.size();
	resize(imgOriginal, imgResized, Size(), scale, scale);
	cout << "\nimgResized.size(): " << imgResized.size() << "\n";

	// Preprpcessing - Step 1 
	imgThre = DetectEdges::imageProcessing(imgResized);

	// Get Contours - Biggest  - Step 2
	vector<Point> initialPoints = DetectEdges::getContours(imgThre, imgResized);
	DetectEdges::drawPoints(initialPoints, Scalar(0, 255, 0), imgResized);
	//vector<Point> docPoints = DetectEdges::reorder(initialPoints);
	//DetectEdges::drawPoints(docPoints, Scalar(0, 255, 0));
	cout << "initialPoints: " << initialPoints << "\n";
	//cout << "docPoints: " << docPoints << "\n";

	// Warp - Step 3 
	//imgWarp = getWarp(imgOriginal, docPoints, w, h);

	//Crop - Step 4
	/*int cropVal = 5;
	Rect roi(cropVal, cropVal, w - (2 * cropVal), h - (2 * cropVal));
	imgCrop = imgWarp(roi);*/

	//imshow("Image", imgResized);
	//imshow("Image Dilation", imgThre);
	//imshow("Image Warp", imgWarp);
	//imshow("Image Crop", imgCrop);
	//waitKey(0);

	//return imgThre;

	string str(path);
	DetectEdges::saveImage(imgResized, "imgThre", str);


	return 0;
	
	/////////////////////////

	const int height = imgThre.size().height;
	const int width = imgThre.size().width;
	const int area = height * width;

	vector<unsigned char> buffer;
	uchar* p;
	for (int i = 0; i < height; ++i) {
		p = imgThre.ptr<uchar>(i);
		for (int j = 0; j < width; ++j) {
			buffer.push_back(p[j]);
		}
	}
	//return buffer;
}
