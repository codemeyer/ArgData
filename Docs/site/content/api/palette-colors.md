---
title: "ArgData: Palette Colors"
---

# Palette Colors

The palette in F1GP contains 256 colors.

There are at least two palettes, one that is used when you are racing,
and one that is used in the game menus. Aside from that, the kerb colors have their own indexes.

Some tracks change the green and grey colors slightly.


## "Racing" palette

The green colors around index 18 and the gray colors around index 26 shift slightly per circuit
(using track command 0xAC) and should not be used for such things as painting cars with.

<table class="table table-bordered table-striped table--medium">
    <thead>
        <tr>
            <th>Index</th>
            <th>Color</th>
            <th>Example</th>
            <th>Comment</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>0</td>
            <td>#000000</td>
            <td><div class="palette-color" style="background-color: #000000"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>1</td>
            <td>#BEBEBE</td>
            <td><div class="palette-color" style="background-color: #BEBEBE"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>2</td>
            <td>#C6483A</td>
            <td><div class="palette-color" style="background-color: #C6483A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>3</td>
            <td>#FFEF00</td>
            <td><div class="palette-color" style="background-color: #FFEF00"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>4</td>
            <td>#008400</td>
            <td><div class="palette-color" style="background-color: #008400"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>5</td>
            <td>#3D0FA0</td>
            <td><div class="palette-color" style="background-color: #3D0FA0"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>6</td>
            <td>#579DFF</td>
            <td><div class="palette-color" style="background-color: #579DFF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>7</td>
            <td>#7D7D7D</td>
            <td><div class="palette-color" style="background-color: #7D7D7D"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>8</td>
            <td>#FFFFFF</td>
            <td><div class="palette-color" style="background-color: #FFFFFF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>9</td>
            <td>#FF503A</td>
            <td><div class="palette-color" style="background-color: #FF503A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>10</td>
            <td>#5D5D5D</td>
            <td><div class="palette-color" style="background-color: #5D5D5D"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>11</td>
            <td>#004E00</td>
            <td><div class="palette-color" style="background-color: #004E00"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>12</td>
            <td>#9E9E9E</td>
            <td><div class="palette-color" style="background-color: #9E9E9E"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>13</td>
            <td>#BEBEBE</td>
            <td><div class="palette-color" style="background-color: #BEBEBE"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>14</td>
            <td>#DFDFDF</td>
            <td><div class="palette-color" style="background-color: #DFDFDF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>15</td>
            <td>#006900</td>
            <td><div class="palette-color" style="background-color: #006900"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>16</td>
            <td>#497B2D</td>
            <td><div class="palette-color" style="background-color: #497B2D"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>17</td>
            <td>#4D7F31</td>
            <td><div class="palette-color" style="background-color: #4D7F31"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>18</td>
            <td>#518335</td>
            <td><div class="palette-color" style="background-color: #518335"></div></td>
            <td>Grass color, may shift slightly between circuits</td>
        </tr>
        <tr>
            <td>19</td>
            <td>#558739</td>
            <td><div class="palette-color" style="background-color: #558739"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>20</td>
            <td>#5A8842</td>
            <td><div class="palette-color" style="background-color: #5A8842"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>21</td>
            <td>#628C50</td>
            <td><div class="palette-color" style="background-color: #628C50"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>22</td>
            <td>#6E8F5A</td>
            <td><div class="palette-color" style="background-color: #6E8F5A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>23</td>
            <td>#769367</td>
            <td><div class="palette-color" style="background-color: #769367"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>24</td>
            <td>#828286</td>
            <td><div class="palette-color" style="background-color: #828286"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>25</td>
            <td>#86868A</td>
            <td><div class="palette-color" style="background-color: #86868A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>26</td>
            <td>#8A8A8E</td>
            <td><div class="palette-color" style="background-color: #8A8A8E"></div></td>
            <td>Asphalt/tarmac color, may shift slightly between circuits</td>
        </tr>
        <tr>
            <td>27</td>
            <td>#8E8E92</td>
            <td><div class="palette-color" style="background-color: #8E8E92"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>28</td>
            <td>#8E8E92</td>
            <td><div class="palette-color" style="background-color: #8E8E92"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>29</td>
            <td>#929296</td>
            <td><div class="palette-color" style="background-color: #929296"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>30</td>
            <td>#969696</td>
            <td><div class="palette-color" style="background-color: #969696"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>31</td>
            <td>#9A9A96</td>
            <td><div class="palette-color" style="background-color: #9A9A96"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>32</td>
            <td>#000000</td>
            <td><div class="palette-color" style="background-color: #000000"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>33</td>
            <td>#1C1C1C</td>
            <td><div class="palette-color" style="background-color: #1C1C1C"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>34</td>
            <td>#2C2C2C</td>
            <td><div class="palette-color" style="background-color: #2C2C2C"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>35</td>
            <td>#3C3C3C</td>
            <td><div class="palette-color" style="background-color: #3C3C3C"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>36</td>
            <td>#4D4D4D</td>
            <td><div class="palette-color" style="background-color: #4D4D4D"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>37</td>
            <td>#5D5D5D</td>
            <td><div class="palette-color" style="background-color: #5D5D5D"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>38</td>
            <td>#6D6D6D</td>
            <td><div class="palette-color" style="background-color: #6D6D6D"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>39</td>
            <td>#7D7D7D</td>
            <td><div class="palette-color" style="background-color: #7D7D7D"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>40</td>
            <td>#8E8E8E</td>
            <td><div class="palette-color" style="background-color: #8E8E8E"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>41</td>
            <td>#9E9E9E</td>
            <td><div class="palette-color" style="background-color: #9E9E9E"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>42</td>
            <td>#AEAEAE</td>
            <td><div class="palette-color" style="background-color: #AEAEAE"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>43</td>
            <td>#BEBEBE</td>
            <td><div class="palette-color" style="background-color: #BEBEBE"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>44</td>
            <td>#CFCFCF</td>
            <td><div class="palette-color" style="background-color: #CFCFCF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>45</td>
            <td>#DFDFDF</td>
            <td><div class="palette-color" style="background-color: #DFDFDF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>46</td>
            <td>#EFEFEF</td>
            <td><div class="palette-color" style="background-color: #EFEFEF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>47</td>
            <td>#FFFFFF</td>
            <td><div class="palette-color" style="background-color: #FFFFFF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>48</td>
            <td>#000000</td>
            <td><div class="palette-color" style="background-color: #000000"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>49</td>
            <td>#1D0307</td>
            <td><div class="palette-color" style="background-color: #1D0307"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>50</td>
            <td>#2E050A</td>
            <td><div class="palette-color" style="background-color: #2E050A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>51</td>
            <td>#40060C</td>
            <td><div class="palette-color" style="background-color: #40060C"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>52</td>
            <td>#51080F</td>
            <td><div class="palette-color" style="background-color: #51080F"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>53</td>
            <td>#620A0E</td>
            <td><div class="palette-color" style="background-color: #620A0E"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>54</td>
            <td>#740B13</td>
            <td><div class="palette-color" style="background-color: #740B13"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>55</td>
            <td>#850D13</td>
            <td><div class="palette-color" style="background-color: #850D13"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>56</td>
            <td>#971017</td>
            <td><div class="palette-color" style="background-color: #971017"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>57</td>
            <td>#A81016</td>
            <td><div class="palette-color" style="background-color: #A81016"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>58</td>
            <td>#B8131A</td>
            <td><div class="palette-color" style="background-color: #B8131A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>59</td>
            <td>#CA141A</td>
            <td><div class="palette-color" style="background-color: #CA141A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>60</td>
            <td>#DD161E</td>
            <td><div class="palette-color" style="background-color: #DD161E"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>61</td>
            <td>#EE181E</td>
            <td><div class="palette-color" style="background-color: #EE181E"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>62</td>
            <td>#FE1A21</td>
            <td><div class="palette-color" style="background-color: #FE1A21"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>63</td>
            <td>#FF1C23</td>
            <td><div class="palette-color" style="background-color: #FF1C23"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>64</td>
            <td>#000000</td>
            <td><div class="palette-color" style="background-color: #000000"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>65</td>
            <td>#071806</td>
            <td><div class="palette-color" style="background-color: #071806"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>66</td>
            <td>#0E270E</td>
            <td><div class="palette-color" style="background-color: #0E270E"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>67</td>
            <td>#113513</td>
            <td><div class="palette-color" style="background-color: #113513"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>68</td>
            <td>#144516</td>
            <td><div class="palette-color" style="background-color: #144516"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>69</td>
            <td>#135116</td>
            <td><div class="palette-color" style="background-color: #135116"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>70</td>
            <td>#17601A</td>
            <td><div class="palette-color" style="background-color: #17601A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>71</td>
            <td>#166C1A</td>
            <td><div class="palette-color" style="background-color: #166C1A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>72</td>
            <td>#197C1D</td>
            <td><div class="palette-color" style="background-color: #197C1D"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>73</td>
            <td>#17891D</td>
            <td><div class="palette-color" style="background-color: #17891D"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>74</td>
            <td>#17971E</td>
            <td><div class="palette-color" style="background-color: #17971E"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>75</td>
            <td>#1AA521</td>
            <td><div class="palette-color" style="background-color: #1AA521"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>76</td>
            <td>#19B320</td>
            <td><div class="palette-color" style="background-color: #19B320"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>77</td>
            <td>#19C020</td>
            <td><div class="palette-color" style="background-color: #19C020"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>78</td>
            <td>#18CE20</td>
            <td><div class="palette-color" style="background-color: #18CE20"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>79</td>
            <td>#16DC1F</td>
            <td><div class="palette-color" style="background-color: #16DC1F"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>80</td>
            <td>#000000</td>
            <td><div class="palette-color" style="background-color: #000000"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>81</td>
            <td>#08021B</td>
            <td><div class="palette-color" style="background-color: #08021B"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>82</td>
            <td>#0B032C</td>
            <td><div class="palette-color" style="background-color: #0B032C"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>83</td>
            <td>#0C043D</td>
            <td><div class="palette-color" style="background-color: #0C043D"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>84</td>
            <td>#10054E</td>
            <td><div class="palette-color" style="background-color: #10054E"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>85</td>
            <td>#0F075F</td>
            <td><div class="palette-color" style="background-color: #0F075F"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>86</td>
            <td>#13086F</td>
            <td><div class="palette-color" style="background-color: #13086F"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>87</td>
            <td>#14097F</td>
            <td><div class="palette-color" style="background-color: #14097F"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>88</td>
            <td>#170B91</td>
            <td><div class="palette-color" style="background-color: #170B91"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>89</td>
            <td>#170CA1</td>
            <td><div class="palette-color" style="background-color: #170CA1"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>90</td>
            <td>#1C0DB1</td>
            <td><div class="palette-color" style="background-color: #1C0DB1"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>91</td>
            <td>#1B0EC1</td>
            <td><div class="palette-color" style="background-color: #1B0EC1"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>92</td>
            <td>#1F10D3</td>
            <td><div class="palette-color" style="background-color: #1F10D3"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>93</td>
            <td>#1F10E2</td>
            <td><div class="palette-color" style="background-color: #1F10E2"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>94</td>
            <td>#2311F2</td>
            <td><div class="palette-color" style="background-color: #2311F2"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>95</td>
            <td>#2212FF</td>
            <td><div class="palette-color" style="background-color: #2212FF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>96</td>
            <td>#000000</td>
            <td><div class="palette-color" style="background-color: #000000"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>97</td>
            <td>#1C1A07</td>
            <td><div class="palette-color" style="background-color: #1C1A07"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>98</td>
            <td>#2B2A0B</td>
            <td><div class="palette-color" style="background-color: #2B2A0B"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>99</td>
            <td>#3C390A</td>
            <td><div class="palette-color" style="background-color: #3C390A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>100</td>
            <td>#4C4A0E</td>
            <td><div class="palette-color" style="background-color: #4C4A0E"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>101</td>
            <td>#5D580D</td>
            <td><div class="palette-color" style="background-color: #5D580D"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>102</td>
            <td>#6D6710</td>
            <td><div class="palette-color" style="background-color: #6D6710"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>103</td>
            <td>#7D7711</td>
            <td><div class="palette-color" style="background-color: #7D7711"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>104</td>
            <td>#8E8715</td>
            <td><div class="palette-color" style="background-color: #8E8715"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>105</td>
            <td>#9F9514</td>
            <td><div class="palette-color" style="background-color: #9F9514"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>106</td>
            <td>#AFA518</td>
            <td><div class="palette-color" style="background-color: #AFA518"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>107</td>
            <td>#BFB418</td>
            <td><div class="palette-color" style="background-color: #BFB418"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>108</td>
            <td>#D1C51B</td>
            <td><div class="palette-color" style="background-color: #D1C51B"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>109</td>
            <td>#E0D41B</td>
            <td><div class="palette-color" style="background-color: #E0D41B"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>110</td>
            <td>#F1E21E</td>
            <td><div class="palette-color" style="background-color: #F1E21E"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>111</td>
            <td>#FFF21E</td>
            <td><div class="palette-color" style="background-color: #FFF21E"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>112</td>
            <td>#731700</td>
            <td><div class="palette-color" style="background-color: #731700"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>113</td>
            <td>#832D00</td>
            <td><div class="palette-color" style="background-color: #832D00"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>114</td>
            <td>#952500</td>
            <td><div class="palette-color" style="background-color: #952500"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>115</td>
            <td>#A53500</td>
            <td><div class="palette-color" style="background-color: #A53500"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>116</td>
            <td>#B64400</td>
            <td><div class="palette-color" style="background-color: #B64400"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>117</td>
            <td>#C55400</td>
            <td><div class="palette-color" style="background-color: #C55400"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>118</td>
            <td>#D76300</td>
            <td><div class="palette-color" style="background-color: #D76300"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>119</td>
            <td>#E87100</td>
            <td><div class="palette-color" style="background-color: #E87100"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>120</td>
            <td>#2D1100</td>
            <td><div class="palette-color" style="background-color: #2D1100"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>121</td>
            <td>#3D2700</td>
            <td><div class="palette-color" style="background-color: #3D2700"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>122</td>
            <td>#511F00</td>
            <td><div class="palette-color" style="background-color: #511F00"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>123</td>
            <td>#602E00</td>
            <td><div class="palette-color" style="background-color: #602E00"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>124</td>
            <td>#703D00</td>
            <td><div class="palette-color" style="background-color: #703D00"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>125</td>
            <td>#804D00</td>
            <td><div class="palette-color" style="background-color: #804D00"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>126</td>
            <td>#925C00</td>
            <td><div class="palette-color" style="background-color: #925C00"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>127</td>
            <td>#A26B00</td>
            <td><div class="palette-color" style="background-color: #A26B00"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>128</td>
            <td>#4293FF</td>
            <td><div class="palette-color" style="background-color: #4293FF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>129</td>
            <td>#4698FF</td>
            <td><div class="palette-color" style="background-color: #4698FF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>130</td>
            <td>#4A9CFF</td>
            <td><div class="palette-color" style="background-color: #4A9CFF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>131</td>
            <td>#4E9FFF</td>
            <td><div class="palette-color" style="background-color: #4E9FFF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>132</td>
            <td>#52A4FF</td>
            <td><div class="palette-color" style="background-color: #52A4FF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>133</td>
            <td>#57A7FF</td>
            <td><div class="palette-color" style="background-color: #57A7FF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>134</td>
            <td>#5BABFF</td>
            <td><div class="palette-color" style="background-color: #5BABFF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>135</td>
            <td>#5EAEFF</td>
            <td><div class="palette-color" style="background-color: #5EAEFF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>136</td>
            <td>#113C13</td>
            <td><div class="palette-color" style="background-color: #113C13"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>137</td>
            <td>#144A17</td>
            <td><div class="palette-color" style="background-color: #144A17"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>138</td>
            <td>#104112</td>
            <td><div class="palette-color" style="background-color: #104112"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>139</td>
            <td>#144716</td>
            <td><div class="palette-color" style="background-color: #144716"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>140</td>
            <td>#134F16</td>
            <td><div class="palette-color" style="background-color: #134F16"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>141</td>
            <td>#F9EB2A</td>
            <td><div class="palette-color" style="background-color: #F9EB2A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>142</td>
            <td>#F1E43D</td>
            <td><div class="palette-color" style="background-color: #F1E43D"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>143</td>
            <td>#E7DE49</td>
            <td><div class="palette-color" style="background-color: #E7DE49"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>144</td>
            <td>#214C23</td>
            <td><div class="palette-color" style="background-color: #214C23"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>145</td>
            <td>#3C654C</td>
            <td><div class="palette-color" style="background-color: #3C654C"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>146</td>
            <td>#486F57</td>
            <td><div class="palette-color" style="background-color: #486F57"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>147</td>
            <td>#577764</td>
            <td><div class="palette-color" style="background-color: #577764"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>148</td>
            <td>#316340</td>
            <td><div class="palette-color" style="background-color: #316340"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>149</td>
            <td>#3D694C</td>
            <td><div class="palette-color" style="background-color: #3D694C"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>150</td>
            <td>#4C755A</td>
            <td><div class="palette-color" style="background-color: #4C755A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>151</td>
            <td>#5B7E68</td>
            <td><div class="palette-color" style="background-color: #5B7E68"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>152</td>
            <td>#618D6F</td>
            <td><div class="palette-color" style="background-color: #618D6F"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>153</td>
            <td>#6F9B7D</td>
            <td><div class="palette-color" style="background-color: #6F9B7D"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>154</td>
            <td>#7DA98B</td>
            <td><div class="palette-color" style="background-color: #7DA98B"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>155</td>
            <td>#8CB89A</td>
            <td><div class="palette-color" style="background-color: #8CB89A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>156</td>
            <td>#9AC6A8</td>
            <td><div class="palette-color" style="background-color: #9AC6A8"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>157</td>
            <td>#A8D4B6</td>
            <td><div class="palette-color" style="background-color: #A8D4B6"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>158</td>
            <td>#D5D56E</td>
            <td><div class="palette-color" style="background-color: #D5D56E"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>159</td>
            <td>#C4F1D3</td>
            <td><div class="palette-color" style="background-color: #C4F1D3"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>160</td>
            <td>#3C32D3</td>
            <td><div class="palette-color" style="background-color: #3C32D3"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>161</td>
            <td>#4642CF</td>
            <td><div class="palette-color" style="background-color: #4642CF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>162</td>
            <td>#5450CF</td>
            <td><div class="palette-color" style="background-color: #5450CF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>163</td>
            <td>#605DCA</td>
            <td><div class="palette-color" style="background-color: #605DCA"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>164</td>
            <td>#CE3847</td>
            <td><div class="palette-color" style="background-color: #CE3847"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>165</td>
            <td>#C94852</td>
            <td><div class="palette-color" style="background-color: #C94852"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>166</td>
            <td>#C95461</td>
            <td><div class="palette-color" style="background-color: #C95461"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>167</td>
            <td>#C3606C</td>
            <td><div class="palette-color" style="background-color: #C3606C"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>168</td>
            <td>#8E936F</td>
            <td><div class="palette-color" style="background-color: #8E936F"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>169</td>
            <td>#9CA17D</td>
            <td><div class="palette-color" style="background-color: #9CA17D"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>170</td>
            <td>#AAAF8B</td>
            <td><div class="palette-color" style="background-color: #AAAF8B"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>171</td>
            <td>#B8BC99</td>
            <td><div class="palette-color" style="background-color: #B8BC99"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>172</td>
            <td>#C7CBA7</td>
            <td><div class="palette-color" style="background-color: #C7CBA7"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>173</td>
            <td>#D5D9B5</td>
            <td><div class="palette-color" style="background-color: #D5D9B5"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>174</td>
            <td>#E3E7C3</td>
            <td><div class="palette-color" style="background-color: #E3E7C3"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>175</td>
            <td>#F1F5D2</td>
            <td><div class="palette-color" style="background-color: #F1F5D2"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>176</td>
            <td>#949A87</td>
            <td><div class="palette-color" style="background-color: #949A87"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>177</td>
            <td>#9FA593</td>
            <td><div class="palette-color" style="background-color: #9FA593"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>178</td>
            <td>#ADB3A1</td>
            <td><div class="palette-color" style="background-color: #ADB3A1"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>179</td>
            <td>#C0C4AA</td>
            <td><div class="palette-color" style="background-color: #C0C4AA"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>180</td>
            <td>#CAD0B9</td>
            <td><div class="palette-color" style="background-color: #CAD0B9"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>181</td>
            <td>#D5DACC</td>
            <td><div class="palette-color" style="background-color: #D5DACC"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>182</td>
            <td>#E2E8D7</td>
            <td><div class="palette-color" style="background-color: #E2E8D7"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>183</td>
            <td>#F0F6E1</td>
            <td><div class="palette-color" style="background-color: #F0F6E1"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>184</td>
            <td>#959B93</td>
            <td><div class="palette-color" style="background-color: #959B93"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>185</td>
            <td>#9FA6A1</td>
            <td><div class="palette-color" style="background-color: #9FA6A1"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>186</td>
            <td>#ADB4AC</td>
            <td><div class="palette-color" style="background-color: #ADB4AC"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>187</td>
            <td>#C0C5B9</td>
            <td><div class="palette-color" style="background-color: #C0C5B9"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>188</td>
            <td>#D2D2C6</td>
            <td><div class="palette-color" style="background-color: #D2D2C6"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>189</td>
            <td>#DFDED2</td>
            <td><div class="palette-color" style="background-color: #DFDED2"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>190</td>
            <td>#EFEEDE</td>
            <td><div class="palette-color" style="background-color: #EFEEDE"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>191</td>
            <td>#FFFEEE</td>
            <td><div class="palette-color" style="background-color: #FFFEEE"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>192</td>
            <td>#6D7519</td>
            <td><div class="palette-color" style="background-color: #6D7519"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>193</td>
            <td>#7D8529</td>
            <td><div class="palette-color" style="background-color: #7D8529"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>194</td>
            <td>#8E9739</td>
            <td><div class="palette-color" style="background-color: #8E9739"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>195</td>
            <td>#9EA64A</td>
            <td><div class="palette-color" style="background-color: #9EA64A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>196</td>
            <td>#AEB65A</td>
            <td><div class="palette-color" style="background-color: #AEB65A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>197</td>
            <td>#BEC66A</td>
            <td><div class="palette-color" style="background-color: #BEC66A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>198</td>
            <td>#CFD87A</td>
            <td><div class="palette-color" style="background-color: #CFD87A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>199</td>
            <td>#DFE78B</td>
            <td><div class="palette-color" style="background-color: #DFE78B"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>200</td>
            <td>#915F3A</td>
            <td><div class="palette-color" style="background-color: #915F3A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>201</td>
            <td>#A2704B</td>
            <td><div class="palette-color" style="background-color: #A2704B"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>202</td>
            <td>#B2805B</td>
            <td><div class="palette-color" style="background-color: #B2805B"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>203</td>
            <td>#C2906B</td>
            <td><div class="palette-color" style="background-color: #C2906B"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>204</td>
            <td>#D2A07B</td>
            <td><div class="palette-color" style="background-color: #D2A07B"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>205</td>
            <td>#E3B18C</td>
            <td><div class="palette-color" style="background-color: #E3B18C"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>206</td>
            <td>#F3C19C</td>
            <td><div class="palette-color" style="background-color: #F3C19C"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>207</td>
            <td>#FFD1AC</td>
            <td><div class="palette-color" style="background-color: #FFD1AC"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>208</td>
            <td>#000304</td>
            <td><div class="palette-color" style="background-color: #000304"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>209</td>
            <td>#000707</td>
            <td><div class="palette-color" style="background-color: #000707"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>210</td>
            <td>#000E0F</td>
            <td><div class="palette-color" style="background-color: #000E0F"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>211</td>
            <td>#001517</td>
            <td><div class="palette-color" style="background-color: #001517"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>212</td>
            <td>#001C1F</td>
            <td><div class="palette-color" style="background-color: #001C1F"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>213</td>
            <td>#002427</td>
            <td><div class="palette-color" style="background-color: #002427"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>214</td>
            <td>#002B30</td>
            <td><div class="palette-color" style="background-color: #002B30"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>215</td>
            <td>#003237</td>
            <td><div class="palette-color" style="background-color: #003237"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>216</td>
            <td>#003A41</td>
            <td><div class="palette-color" style="background-color: #003A41"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>217</td>
            <td>#003E44</td>
            <td><div class="palette-color" style="background-color: #003E44"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>218</td>
            <td>#00444D</td>
            <td><div class="palette-color" style="background-color: #00444D"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>219</td>
            <td>#004C54</td>
            <td><div class="palette-color" style="background-color: #004C54"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>220</td>
            <td>#00545C</td>
            <td><div class="palette-color" style="background-color: #00545C"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>221</td>
            <td>#005A65</td>
            <td><div class="palette-color" style="background-color: #005A65"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>222</td>
            <td>#00626D</td>
            <td><div class="palette-color" style="background-color: #00626D"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>223</td>
            <td>#006A74</td>
            <td><div class="palette-color" style="background-color: #006A74"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>224</td>
            <td>#00707D</td>
            <td><div class="palette-color" style="background-color: #00707D"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>225</td>
            <td>#007583</td>
            <td><div class="palette-color" style="background-color: #007583"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>226</td>
            <td>#007B8A</td>
            <td><div class="palette-color" style="background-color: #007B8A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>227</td>
            <td>#008392</td>
            <td><div class="palette-color" style="background-color: #008392"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>228</td>
            <td>#008A9A</td>
            <td><div class="palette-color" style="background-color: #008A9A"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>229</td>
            <td>#0091A2</td>
            <td><div class="palette-color" style="background-color: #0091A2"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>230</td>
            <td>#0099AA</td>
            <td><div class="palette-color" style="background-color: #0099AA"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>231</td>
            <td>#009FB2</td>
            <td><div class="palette-color" style="background-color: #009FB2"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>232</td>
            <td>#62B3FF</td>
            <td><div class="palette-color" style="background-color: #62B3FF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>233</td>
            <td>#66B6FF</td>
            <td><div class="palette-color" style="background-color: #66B6FF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>234</td>
            <td>#6ABAFF</td>
            <td><div class="palette-color" style="background-color: #6ABAFF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>235</td>
            <td>#6EBEFF</td>
            <td><div class="palette-color" style="background-color: #6EBEFF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>236</td>
            <td>#72C3FF</td>
            <td><div class="palette-color" style="background-color: #72C3FF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>237</td>
            <td>#77C6FF</td>
            <td><div class="palette-color" style="background-color: #77C6FF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>238</td>
            <td>#7BCAFF</td>
            <td><div class="palette-color" style="background-color: #7BCAFF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>239</td>
            <td>#7FCDFF</td>
            <td><div class="palette-color" style="background-color: #7FCDFF"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>240</td>
            <td>#1B202B</td>
            <td><div class="palette-color" style="background-color: #1B202B"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>241</td>
            <td>#1F242F</td>
            <td><div class="palette-color" style="background-color: #1F242F"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>242</td>
            <td>#232838</td>
            <td><div class="palette-color" style="background-color: #232838"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>243</td>
            <td>#262F3B</td>
            <td><div class="palette-color" style="background-color: #262F3B"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>244</td>
            <td>#2B3345</td>
            <td><div class="palette-color" style="background-color: #2B3345"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>245</td>
            <td>#333848</td>
            <td><div class="palette-color" style="background-color: #333848"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>246</td>
            <td>#374150</td>
            <td><div class="palette-color" style="background-color: #374150"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>247</td>
            <td>#404658</td>
            <td><div class="palette-color" style="background-color: #404658"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>248</td>
            <td>#444D5C</td>
            <td><div class="palette-color" style="background-color: #444D5C"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>249</td>
            <td>#485064</td>
            <td><div class="palette-color" style="background-color: #485064"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>250</td>
            <td>#505968</td>
            <td><div class="palette-color" style="background-color: #505968"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>251</td>
            <td>#545C70</td>
            <td><div class="palette-color" style="background-color: #545C70"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>252</td>
            <td>#5C6274</td>
            <td><div class="palette-color" style="background-color: #5C6274"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>253</td>
            <td>#60687C</td>
            <td><div class="palette-color" style="background-color: #60687C"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>254</td>
            <td>#687285</td>
            <td><div class="palette-color" style="background-color: #687285"></div></td>
            <td></td>
        </tr>
        <tr>
            <td>255</td>
            <td>#FFFFFF</td>
            <td><div class="palette-color" style="background-color: #FFFFFF"></div></td>
            <td></td>
        </tr>
    </tbody>
</table>
