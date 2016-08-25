# CSS Basics

*Style and format your web site using CSS*

## Contents

- [What is CSS?](#what-is-css)
- [How does CSS work?](#how-does-css-work)
- [What is the difference between ID and class?](#what-is-the-difference-between-id-and-class)
- [What does a CSS file look like?](#what-does-a-css-file-look-like)
- [Adding CSS to HTML](#adding-css-to-html)
- [Adding IDs and Classes to HTML](#adding-ids-and-classes-to-html)
- [Defining Elements in CSS](#defining-elements-in-css)
- [Writing CSS](#writing-css)
- [Using Fonts in CSS](#using-fonts-in-css)
- [More Info on CSS](#more-info-on-css)




### What is CSS?

CSS (Cascading Style Sheets) allows us to apply formatting and styling to the HTML content that builds our web pages.  

CSS can control many attributes of our web pages: colors, fonts, alignment, borders, backgrounds, spacing, margins, and much more.




### How does CSS work?

CSS works in conjunction with HTML.

An HTML file links to one or many CSS files and when the web browser displays the page, it references the CSS file(s) to determine how to display the content.

HTML elements are marked with “IDs” and “classes,” which are defined in the CSS file – this is how the browser knows which styles belong where. Each element type (`<h1>, <img>, <p>, <li>`, etc.) can also be selected and styled with CSS.
IDs and classes are defined by the person writing the code – there are no default IDs and classes.




### What is the difference between ID and class?

IDs and classes function the same way – they can both provide the same styling functionality to an HTML element, however…

  - IDs are unique;  each element can only have one ID, and that ID can only be on the page once.
  - Classes are not unique;  an element can have multiple classes, and multiple elements can have the same class.
  
What does that mean?

  - IDs can be used to style elements that are different from anything else on the page.
  - Classes can be used to style multiple elements on a single page that have things in common, like font size, color, or style.



### What does a CSS file look like?

The styles for each element, ID, or class used on an HTML page are defined in a CSS document.

Elements are declared with the element (HTML) tag;  styles for the element are wrapped with curly brackets:

```css
h1 {
  ...
}
```

IDs are declared with a pound sign and the ID name; styles for the ID are wrapped with curly brackets:

```css
#title {
  ...
}
```

Classes are declared with a period and the class name; styles for the class are wrapped with curly brackets:

```css
.bodyText {
  ...
}
```

Within each CSS element, styles are added that apply to that particular element/ID/class:

```css
h1 {
  color: green;
}
```

*This style would apply to anything within HTML `<h1></h1>` tags; the text inside the tags would be green.*



### Adding CSS to HTML

CSS must be used in conjunction with HTML to be effective.  CSS files can be linked to HTML documents with a bit of code in the <head></head> tags of an HTML file:

`<link rel="stylesheet" type="text/css" href=“myfile.css" />`

CSS can also be written “in line,” within HTML code, but it’s preferable to include an external style sheet:

`<p style=“font-size: 14px;”>Lorem ipsum…</p>`



### Adding IDs and Classes to HTML

First, we need to add our IDs and classes to the HTML:

```html
<h1>Cougar</h1>

<img src="http://www.byu.edu/web/images/cougar.jpg" class=“bordered” />
<!-- The `bordered` class won’t do anything yet until we define its associated styles in our CSS file.-->

<p id="introduction" class="emphasis">IS is so cool…</p>
<!-- We’re adding a class and an ID to this paragraph; we want the styles from both to be applied to it. -->

<p class="emphasis">The adult cougar is about the size of a medium dog, with a length usually ranging from…</p>
<!-- We only want the styles from one class to apply to this paragraph. -->

```



### Defining Elements in CSS
We’ve added IDs and classes to our HTML file, but we need to define what those IDs and classes will do.  How will each class or ID change the appearance of that HTML element?  This is where CSS comes in!  By defining the styles that go with each attribute/class/ID, we have complete control over the look of our content.



### Writing CSS

Let’s create a new CSS file, `styles.css`

We’ll begin by defining the “bordered” class that is applied to one of the images.

CSS uses `.` (period) to identify classes, and `#` to identify IDs. Because our HTML indicates `class=“bordered”` we need to use the matching identifier in our CSS document.


```css
/* styles.css */

.bordered {
  /* these styles are applied to the image with class="bordered" */
  ...
}

```

First, let’s add a simple style to .bordered:

```css
.bordered {
  width: 300px; /* each style ends with a semi-colon */
}

/* Now, any HTML element that includes class=“border” will be 300 pixels wide. */
```

Let’s add a border to that image that has class=“bordered”. The “border” style requires some additional attributes.

```css
.bordered {
  width: 300px;
  border: 3px solid #000000;
  
  /*
    Tells the browser “I want a border around this element.”:
      - The border should be 3 pixels wide.
      - The border should be solid. (Other possible values include dotted and dashed.)
      - The border should be black (defined by hexadecimal color code).
  */
}
```

We want the image to be on the right side of the page, so we need to add a “float” to the class styles:

```css
.bordered {
  width: 300px;
  border: 3px solid #000000;
  float: right; /* We could also align the element to the left side of the page using “float: left;”. */
}
```

Next, let’s write some styles to apply to our paragraphs. First, we’ll create styles for the ID called “introduction.”

We want this paragraph to stand out from the rest, so we’ll make the font size bigger and change the color.

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
	font-family: “Arial”, sans-serif;
	/*
	  Any <h1> tag on the page will be in Arial unless the <h1> has a class that overwrites it.
	*/
}

```

We may want the same styles to apply to more than one element in our site. Combining our styles can help us do this so that we don’t have to duplicate our CSS code:

```css
h1, h2 {
	font-family:  “Arial”, sans-serif;
}

/*
  Adding additional, comma-separated elements, classes, or IDs allows the same styles to be used in more than one place.
*/

```


### Using Fonts in CSS

Because every computer has a different set of fonts installed by default, we can’t know for sure if our visitors will have a certain font on their computer. 

  - If we design our site using a certain font, and a visitor doesn’t have that font installed, our site will not look as we intended it to.

Luckily, there is a set of “web safe” fonts that most computers have. Choosing from these fonts will make our site look (almost) the same on any computer.

Web safe fonts include: Times New Roman, Georgia, Arial, Tahoma, Verdana. More info: http://www.w3schools.com/cssref/css_websafe_fonts.asp

  - In CSS, the font-family style often includes a list of a few fonts, so that there is a “fallback” option in case the font we specify first isn’t available.


### More Info on CSS

- http://www.w3schools.com/css/
- http://www.csstutorial.net/

