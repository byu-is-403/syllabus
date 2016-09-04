# CSS Basics

*Style and format your web site using CSS*

## Contents

- [What is CSS?](#what-is-css)
- [How does CSS work?](#how-does-css-work)
- [What is the difference between ID and class?](#what-is-the-difference-between-id-and-class)
- [What does a CSS file look like?](#what-does-a-css-file-look-like)
- [Adding CSS to HTML](#adding-css-to-html)
- [Demo: Writing CSS](#demo-writing-css)
- [A note about fonts in CSS](#a-note-about-fonts-in-css)
- [More Info on CSS](#more-info-on-css)


### What is CSS?

CSS (Cascading Style Sheets) allows us to apply formatting and styling to the HTML content that structures our web pages. CSS can control many attributes of our web pages; e.g. colors, fonts, alignment, borders, backgrounds, spacing, margins, and much more.


### How does CSS work?

CSS works in conjunction with HTML by specifying a style for a particular set of elements. A single CSS **rule** is made up of a **selector** and many **properties** and **values**. Now that the jargon is out of the way, lets look at what that looks like:

```css
p {
  color: red;
  font-size: 20px;
}
```

In the previous example, `p` is the selector, `color` and `font-size` are properties, and `red` and `20px` are the values. Selectors don't have to just be tag names - they can also be classes or ids that are included on your HTML elements. For example:

<table>
  <thead>
    <tr>
      <th>HTML</th>
      <th>CSS</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <pre lang="html">
&lt;div id="top-section"&gt;
  &lt;p class="small-type"&gt;
    Hello, world!
  &lt;/p&gt;
&lt;/div&gt;
        </pre>
      </td>
      <td>
        <pre lang="css">
#top-section {
  padding: 100px;
  background: #222;
  color: white;
}

.small-type {
  font-size: 10px;
}
        </pre>
      </td>
    </tr>
  </tbody>
</table>

A CSS rule set can also be made up of many selectors; for example, `.small-type` could also have been written as `p.small-type`, `#top-section .small-type`, or a number of other ways.


### What is the difference between ID and class?

IDs and classes both provide methods of selecting HTML elements. Although they may at first appear very similar, they have some important differences. IDs are unique to an element - each element can only have 1 ID and an ID can only be used on one element on a page at once. Classes, on the other hand, can be applied to many elements and each element can have many classes. Here is an example:

```html
<p class="my-class another-class a-third-class" id="unique-id">
  Hi, world!
</p>

<p id="different-id">Hello again!</p>
```

So, what does this mean? To put it simply, IDs can be used to style elements that are different from anything else on the page. Classes can be used to style multiple elements on a single page that have things in common, like font size, color, or style.


### What does a CSS file look like?

The styles for each element, ID, or class used on an HTML page are defined in a CSS document. Elements are declared with the element (HTML) tag, IDs with the pound sign and the ID name, and classes with a period followed by the class name. Comments are places between `/*` and `*/`. The following shows what a common CSS file might look like:

```css
/* An HTML tag selector */
h1 {
  font-size: 60px;
  margin: 0;
}

/* An ID selector */
#title {
  letter-spacing: -2px;
  color: #FF00FF;
}

/* A class selector */
.large-text {
  font-size: 40px;
}
```


### Adding CSS to HTML

CSS can be written in line with HTML code, but it should generally be avoided:

```html
<!-- Avoid this -->
<p style=“font-size: 14px;”>Lorem ipsum…</p>
```

The better method of using CSS is to link your CSS file to your HTML with a bit of code in the `head` of the document:

```html
<head>
  <!-- Much better -->
  <link rel="stylesheet" type="text/css" href="myfile.css" />
</head>
```


# Demo: Writing CSS

In this section, we will walk through what it is like to write some simple CSS to style an HTML page.

### Writing your HTML

First, we need some HTML to style. The following is a simple HTML page with some facts about cougars:

```html
<!-- index.html -->
<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <title>Cougar Facts</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
  </head>
  <body>
    <h1>Cougar</h1>

    <!-- The `bordered` class won’t do anything yet until we define its associated styles in our CSS file.-->
    <img src="http://www.byu.edu/web/images/cougar.jpg" class=“bordered” />

    <!-- We’re adding a class and an ID to this paragraph; we want the styles from both to be applied to it. -->
    <p id="introduction" class="emphasis">Cougars are my favorite animal.</p>

    <!-- We only want the styles from one class to apply to this paragraph. -->
    <p class="emphasis">The adult cougar is about the size of a medium dog, with a length usually ranging from…</p>

    <!-- This paragraph will have styles from two classes applied. -->
    <p class="emphasis large-text">Never confront a cougar in the wild!</p>
  </body>
</html>
```

IDs and classes are HTML attributes that can be added to any element, much like you might add `src` to and `img` tag. We have added some classes and IDs to various elements on our page. Also note the `link` tag which will include the styles we write.


### Writing CSS

Let’s create a new CSS file, `styles.css`

We’ll begin by defining the “bordered” class that is applied to one of the images.

CSS uses `.` (period) to identify classes, and `#` to identify IDs. Because our HTML indicates `class=“bordered”` we need to use the matching identifier in our CSS document.

```css
/* styles.css */

.bordered {
  width: 300px;
  border: 5px solid #000000;
  float: right;
}
```

With this rule added, any image with the `bordered` class will be 300px wide, have a solid 5px black border, and will align the element to the right side of the page.

Next, let’s write some styles to apply to our paragraphs. First, we’ll create styles for the ID called “introduction.” We want this paragraph to stand out from the rest, so we’ll make the font size bigger and change the color.

```css
#introduction {
  font-size: 20px;
  color: #4d7123;
}
```

We want a few paragraphs to have some additional emphasis, so let’s write an additional class for those styles:

```css
.emphasis {
	font-style: italic; /* Other font-style options include “underline,” and “normal.” */
	font-weight: bold; /* Other font-weight options include “normal,” “lighter,” or numerical values. */
}
```

We can also apply CSS styles to HTML elements without using classes and IDs. These will apply to any HTML element of that type, unless they are overwritten by classes or IDs.

```css
h1 {
	font-family: “Arial”, sans-serif; /* Any <h1> tag on the page will be in Arial unless the <h1> has a class that overwrites it. */
}
```

We may want the same styles to apply to more than one element in our site. Combining our styles can help us do this so that we don’t have to duplicate our CSS code:

```css
h1, h2, p {
	font-family:  “Arial”, sans-serif; /* Adding additional, comma-separated elements, classes, or IDs allows the same styles to be used in more than one place. */
}
```

Put all together, our stylesheet will look like this:

```css
/* styles.css */
.bordered {
  width: 300px;
  border: 5px solid #000000;
  float: right;
}

#introduction {
  font-size: 20px;
  color: #4d7123;
}

.emphasis {
	font-style: italic; /* Other font-style options include “underline,” and “normal.” */
	font-weight: bold; /* Other font-weight options include “normal,” “lighter,” or numerical values. */
}

h1, h2, p {
	font-family:  “Arial”, sans-serif; /* Adding additional, comma-separated elements, classes, or IDs allows the same styles to be used in more than one place. */
}
```

### A note about fonts in CSS

Because every computer has a different set of fonts installed by default, we can’t know for sure if our visitors will have a certain font on their computer. If we design our site using a certain font, and a visitor doesn’t have that font installed, our site will not look as we intended it to. Luckily, there is a set of “web safe” fonts that most computers have. Choosing from these fonts will make our site look (almost) the same on any computer. Web safe fonts include: Times New Roman, Georgia, Arial, Tahoma, Verdana. You can read more at [w3schools.com](http://www.w3schools.com/cssref/css_websafe_fonts.asp).In CSS, the font-family style often includes a list of a few fonts, so that there is a “fallback” option in case the font we specify first isn’t available.


### More Info on CSS

- [Mozilla CSS Reference](https://developer.mozilla.org/en-US/docs/Web/CSS/Reference)
- [W3 Schools](http://www.w3schools.com/css/)
- [CSS Tutorial](http://www.csstutorial.net/)
